/*
 * Problem 7.* Arithmetical expressions
 *
 * Write a program that calculates the value of given arithmetical expression.
 * The expression can contain the following elements only:
 *     Real numbers, e.g. 5, 18.33, 3.14159, 12.6
 *     Arithmetic operators: +, -, *, / (standard priorities)
 *     Mathematical functions: ln(x), sqrt(x), pow(x,y)
 *     Brackets (for changing the default priorities): (, )
 *
 * Examples:
 *  input                                               output
 *  (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)             ~10.6
 *  pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~21.22
 *
 * Hint: Use the classical Shunting-yard algorithm and Reverse Polish notation.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class ArithmeticalExpressions
{
    #region //define global error messages
    static string abuseError = "Too many operator(s)";
    static string argError = "Invalid number of argument(s)";
    static string unrecError = "Unrecognized operation(s)";
    static string delimError = "Misplaced delimiter(s)";
    static string opError = "Misplaced oprator(s)";
    #endregion

    #region //define global variables
    static StringBuilder input = new StringBuilder();
    struct Op
    {
        public string symb;     //the operator symbol; it can be only 1 char long
        public int prior;       //the operator priority; min = 0
        //public string ass;    //the operator associativity; can be "l" (left), "r" (right) or "n" (none)
        public int args;        //the operator argument count; can be 1 (unary), 2 (binary), 3 (ternary) and so on
        public Op(char symbol, int priority, /*char associativity,*/ int args)
        {
            symb = symbol.ToString();
            prior = priority;
            //ass = associativity.ToString();
            this.args = args;
        }
    }
    static List<Op> binOps = new List<Op>()
    {
        new Op('+', 10, 2),    //define '+' operator
        new Op('-', 10, 2),    //define '-' operator
        new Op('*', 20, 2),    //define '*' operator
        new Op('/', 20, 2),    //define '/' operator
    };
    static List<Op> unOps = new List<Op>()
    {
        new Op('+', 30, 1),    //define '+' unary operator
        new Op('-', 30, 1),    //define '-' unary operator
    };
    struct Fn
    {
        public string name;     //the function name
        public int args;        //the function argument count; can be 1 (mono), 2 (bi), 3 (tri) and so on
        public Fn(string name, int args)
        {
            this.name = name.ToString();
            this.args = args;
        }
    }
    static List<Fn> funcs = new List<Fn>()
    {
        new Fn("ln",    1),      //define log function
        new Fn("sqrt",  1),      //define root function
        new Fn("pow",   2),      //define power function
    };
    struct Delim
    {
        public string symb;     //the delimiter symbol; it can be only 1 char long
        public string kind;     //the delimiter kind; can be "s" (function/list argument separator),
        //"b" (start/begin group delimiter, i.e. left parenthesis),
        //"e" (end group delimiter, i.e. right parenthesis)
        public Delim(char symbol, char kind)
        {
            symb = symbol.ToString();
            this.kind = kind.ToString();
        }
    }
    static List<Delim> delims = new List<Delim>()
    {
        new Delim('(', 'b'),     //define '(' delimiter as begin group
        new Delim(',', 's'),     //define ',' delimiter as argument separator
        new Delim(')', 'e'),     //define ')' delimiter as end group
    };
    struct Obj
    {
        public dynamic value;   //the object value; can hold any data type
        public string type;     //the object type; can be "o" (operator), "n" (number), "f" (function), "d" (delimiter)
        public Obj(object value, string type)
        {
            this.value = value;
            this.type = type;
        }
    }
    static Stack<Obj> commonStack = new Stack<Obj>();
    static Queue<Obj> rpnQueue = new Queue<Obj>();
    static string numberPattern = @"^(\d+(\.\d+)?)";
    static string operatorPattern = "^[" + EscapedOperators(binOps) + EscapedOperators(unOps) + "]";
    static string functionPattern = "^(" + ConcatFuncNames(funcs, "|") + ")";
    static string delimPattern = "^[" + EscapedOperators(delims) + "]";
    static string normalizePattern = "([" + EscapedOperators(binOps) + "])" + "([" + EscapedOperators(unOps) + "])";
    static string abusePattern = "[" + EscapedOperators(binOps) + EscapedOperators(unOps) + "]{3,}";
    static bool isInSequence = true;
    #endregion

    /* test input
     * -1 + (-2)                                                ->  RPN: 1-2-+
     *  3 + 4 * 2 / (1 - 5)                                     ->  RPN: 342*15-/+
     * 5 - (6 * 7)                                              ->  RPN: 567*-
     * 5 + ((1 + 2) * 4) - 3                                    ->  RPN: 512+4*+3-
     * (3 + 5.3) * 2.7 - ln(22) / pow(2.2, -1.7)                ->  RPN: 3 5.3 + 2.7 * 22 ln 2.2 1.7 - pow / -
     * pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5 * 0.3)     ->  RPN: 2 3.14 pow 3 3 2 sqrt * 3.2 - - 1.5 0.3 * + *
     */

    static void SetLocalization()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }

    static void ReadInput()
    {
        input = new StringBuilder(Console.ReadLine());
    }

    static void RemoveWhitespace(StringBuilder input)
    {
        input = input.Replace(" ", "");
    }

    static string EscapedOperators(dynamic ops)
    {
        string opChars = string.Empty;
        foreach (var op in ops)
        {
            if (op.symb == "-" || op.symb == "(" || op.symb == ")" || op.symb == "^")
            {
                opChars += @"\";
            }
            opChars += op.symb;
        }
        return opChars;
    }

    static void IsAbused(StringBuilder input)
    {
        if (Regex.IsMatch(input.ToString(), abusePattern))
        {
            throw new FormatException(abuseError);
        }
    }

    static void NormalizeUnary(StringBuilder input)
    {
        Match match;
        do
        {
            match = Regex.Match(input.ToString(), normalizePattern);
            if (match.Groups[2].Value == "+")
            {
                input = input.Remove(match.Index + 1, 1);
            }
            else if (match.Groups[2].Value == "-")
            {
                input = input.Remove(match.Index + 1, 1);
                input = input.Insert(match.Index + 1, "(-1)*");
            }
        } while (match.Success);
    }

    static string ConcatFuncNames(List<Fn> funcs, string delimiter)
    {
        string fnNames = string.Empty;
        for (int i = 0; i < funcs.Count; i++)
        {
            fnNames += funcs[i].name;
            if (i != funcs.Count - 1)
                fnNames += delimiter;
        }
        return fnNames;
    }

    static void ConvertToRpn(StringBuilder input)
    {
        //Shunting-yard algorithm implementation
        Obj token;
        while (input.Length != 0)
        {
            token = ReadToken(input);
            switch (token.type)
            {
                case "n": rpnQueue.Enqueue(token); break;
                case "f": commonStack.Push(token); break;
                case "o":
                    while
                    (
                        commonStack.Count != 0 &&
                        token.type == commonStack.Peek().type &&
                        token.value.prior <= commonStack.Peek().value.prior
                    )
                    {
                        rpnQueue.Enqueue(commonStack.Pop());
                    }
                    commonStack.Push(token);
                    break;
                case "d":
                    if (token.value.kind == "b")
                    {
                        commonStack.Push(token);
                    }
                    else if (token.value.kind == "s")
                    {
                        try                             //search for a start group delimiter, i.e. left parenthesis
                        {                               //it could be a method
                            while
                                (
                                !(commonStack.Peek().type == token.type &&
                                commonStack.Peek().value.kind == "b")
                                )
                            {
                                rpnQueue.Enqueue(commonStack.Pop());
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            throw new FormatException(delimError);
                        }
                    }
                    else if (token.value.kind == "e")
                    {
                        try                             //search for a start group delimiter, i.e. left parenthesis
                        {                               //it could be a method
                            while
                                (
                                !(commonStack.Peek().type == token.type &&
                                commonStack.Peek().value.kind == "b")
                                )
                            {
                                rpnQueue.Enqueue(commonStack.Pop());
                            }
                            commonStack.Pop();
                        }
                        catch (InvalidOperationException)
                        {
                            throw new FormatException(delimError);
                        }
                        if (commonStack.Count != 0 && commonStack.Peek().type == "f")
                        {
                            rpnQueue.Enqueue(commonStack.Pop());
                        }
                    }
                    break;
            }
        }
        while (commonStack.Count != 0)
        {
            if (commonStack.Peek().type == "d")
            {
                throw new FormatException(delimError);
            }
            rpnQueue.Enqueue(commonStack.Pop());
        }
    }

    static Obj ReadToken(StringBuilder input)
    {
        Match match;
        Obj token;

        match = Regex.Match(input.ToString(), numberPattern);
        if (match.Success)                                      //the token is a number
        {
            isInSequence = false;                               //unset the unary operator sequence identification
            token = new Obj(double.Parse(match.Groups[1].Value), "n");
            input = input.Remove(match.Index, match.Length);    //modify the input string
            return token;
        }
        match = Regex.Match(input.ToString(), functionPattern);
        if (match.Success)                                      //the token is a function
        {
            for (int i = 0; i < funcs.Count; i++)               //find which function is it
            {
                if (match.Groups[1].Value == funcs[i].name)     //if function founded
                {
                    isInSequence = false;                               //unset the unary operator sequence identification
                    token = new Obj(funcs[i], "f");
                    input = input.Remove(match.Index, match.Length);    //modify the input string
                    return token;
                }
            }
        }
        match = Regex.Match(input.ToString(), operatorPattern);
        if (match.Success)                                      //the token is an operator
        {
            if (isInSequence)                                   //the token is unary operator
            {
                for (int i = 0; i < unOps.Count; i++)           //find which operator is it, searching the unary ops
                {
                    if (match.Value == unOps[i].symb)           //if operator founded
                    {
                        isInSequence = false;                   //unset the unary operator sequence identification
                        token = new Obj(unOps[i], "o");
                        input = input.Remove(match.Index, 1);   //modify the input string
                        return token;
                    }
                }
            }
            else                                                //the token is binary operator
            {
                for (int i = 0; i < binOps.Count; i++)          //find which operator is it, searching the binary ops
                {
                    if (match.Value == binOps[i].symb)          //if operator founded
                    {
                        token = new Obj(binOps[i], "o");
                        input = input.Remove(match.Index, 1);   //modify the input string
                        return token;
                    }
                }
            }
            throw new FormatException(opError);
        }
        match = Regex.Match(input.ToString(), delimPattern);
        if (match.Success)                                      //the token is a delimiter
        {
            for (int i = 0; i < delims.Count; i++)              //find which delimiter is it
            {
                if (match.Value == delims[i].symb)              //if delimiter founded
                {
                    if (delims[i].kind == "b" || delims[i].kind == "s")
                        isInSequence = true;                    //set the unary operator sequence identification
                    else
                        isInSequence = false;                   //unset the unary operator sequence identification
                    token = new Obj(delims[i], "d");
                    input = input.Remove(match.Index, 1);       //modify the input string
                    return token;
                }
            }
        }
        throw new FormatException(unrecError);                  //exception if no valid match
    }

    static double EvaluateRPN()
    {
        Obj token;
        Obj secondOperand;

        while (rpnQueue.Count != 0)
        {
            token = rpnQueue.Dequeue();
            if (token.type == "n")                              //the token is a number value
            {
                commonStack.Push(token);
            }
            else                                                //the token is either operator or function
            {
                if (commonStack.Count < token.value.args)       //if there are fewer than n values on the stack
                {
                    throw new ArgumentException(argError);
                }
                else
                {
                    if (token.type == "o")                      //the token is an operator
                    {
                        if (token.value.args == 1)              //the token is unary operator
                        {
                            if (token.value.symb == "+")        //the operator is unary +
                            {
                                commonStack.Push(new Obj(commonStack.Pop().value, "n"));
                            }
                            else if (token.value.symb == "-")   //the operator is unary -
                            {
                                commonStack.Push(new Obj(-commonStack.Pop().value, "n"));
                            }
                        }
                        else if (token.value.args == 2)         //the token is binary operator
                        {
                            if (token.value.symb == "+")        //the operator is binary +
                            {
                                commonStack.Push(new Obj(commonStack.Pop().value + commonStack.Pop().value, "n"));
                            }
                            else if (token.value.symb == "-")   //the operator is binary -
                            {
                                secondOperand = commonStack.Pop();
                                commonStack.Push(new Obj(commonStack.Pop().value - secondOperand.value, "n"));
                            }
                            else if (token.value.symb == "*")   //the operator is binary *
                            {
                                commonStack.Push(new Obj(commonStack.Pop().value * commonStack.Pop().value, "n"));
                            }
                            else if (token.value.symb == "/")   //the operator is binary /
                            {
                                secondOperand = commonStack.Pop();
                                commonStack.Push(new Obj(commonStack.Pop().value / secondOperand.value, "n"));
                            }
                        }
                    }
                    else                                        //the token is a function
                    {
                        if (token.value.name == "ln")           //the token is logarithmic function
                        {
                            commonStack.Push(new Obj(Math.Log(commonStack.Pop().value), "n"));
                        }
                        else if (token.value.name == "sqrt")    //the token is root function
                        {
                            commonStack.Push(new Obj(Math.Sqrt(commonStack.Pop().value), "n"));
                        }
                        else if (token.value.name == "pow")     //the token is power function
                        {
                            secondOperand = commonStack.Pop();
                            commonStack.Push(new Obj(Math.Pow(commonStack.Pop().value, secondOperand.value), "n"));
                        }
                    }
                }
            }
        }
        if (commonStack.Count == 1)                             //if only one value - success
        {
            return commonStack.Pop().value;
        }
        else                                                    //otherwise - error
        {
            throw new ArgumentException(argError);
        }
    }

    static void Main()
    {
        //set localization to invariant
        SetLocalization();

        //read input
        ReadInput();
        Console.WriteLine("raw input: " + input);

        //remove white space
        RemoveWhitespace(input);
        Console.WriteLine("clean input: " + input);

        //check input for operator abuse - ensure that no more than 2 operators may appear one after another
        //otherwise, operators are abused
        IsAbused(input);

        //normalize the unary operators in the input
        NormalizeUnary(input);
        Console.WriteLine("normalized input: " + input);

        //convert the tokens into a queue - rpn of the expression
        ConvertToRpn(input);

        //calculate the final result with the shunting-yard algorithm
        double result = EvaluateRPN();

        //print output
        Console.WriteLine("expression result: " + result);
    }
}