using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
/*
 * Problem 2. Reverse string
 *
 * Write a program that reads a string, reverses it and prints the result at the console.
 */
class clReverseString
{
    public static void ReverseString()
    {
        //Console.Write("Enter text to reverse: ");
        string input = "qwerty";    // Console.ReadLine();
        char[] chars = input.ToCharArray();
        Array.Reverse(chars);
        Console.WriteLine(string.Join("", chars));
    }
}
/*
 * Problem 3. Correct brackets
 *
 * Write a program to check if in a given expression the brackets are put correctly.
 *
 * Example of correct expression: ((a+b)/5-d).
 * Example of incorrect expression: )(a+b)).
 */
class clCorrectBrackets
{
    public static void CorrectBrackets()
    {
        string expression = ")(a+b))";      //(a + (3 - 4)) * (b + (-6))
        int brackets = 0;
        for (int i = 0; i < expression.Length && brackets >= 0; i++)
        {
            if (expression[i] == '(')
                brackets++;
            else if (expression[i] == ')')
                brackets--;
        }
        if (brackets != 0)
            Console.WriteLine("Wrong");
        else
            Console.WriteLine("Right");
    }
}
/*
 * Problem 4. Sub-string in text
 *
 * Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
 *
 * Example:
 *
 *  The target sub-string is: "in"
 *
 *  The text is as follows: We are living in an yellow submarine. We don't have anything else.
 *  inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
 *
 *  The result is: 9
 */
class clSubstringInText
{
    public static void SubstringInText()
    {
        //input
        //Console.Write("Enter text to search through: ");
        string text =
@"We are living in an yellow submarine. We don't have anything else.
inside the submarine is very tight. So we are drinking all the day.
We will move out of it in 5 days.";    // Console.ReadLine();
        //Console.Write("Enter search term: ");
        string term = "in";             // Console.ReadLine();

        //logic + output
        Console.WriteLine("Matches: {0}", Regex.Matches(text, term, RegexOptions.IgnoreCase).Count);
    }
}
/*
 * Problem 5. Parse tags
 *
 * You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase>
 * and </upcase> to upper-case.
 * The tags cannot be nested.
 *
 * Example: We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
 *
 *  The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
 */
class clParseTags
{
    public static void ParseTags()
    {
        //input
        //Console.Write("Enter text to search and upcase: ");
        StringBuilder text = new StringBuilder(
@"We are living in an <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
inside the <upcase>submarine</upcase> is very tight. So we are drinking <upcase>all the day</upcase><upcase>.
We</upcase> will move out of it in 5 days.");    // Console.ReadLine();
        //Console.Write("Enter tag name delimiter: ");
        string tagName = "upcase";              // Console.ReadLine();
        string searchPattern = "<" + tagName + ">(.*?)</" + tagName + ">";

        //logic
        Match match = Regex.Match(text.ToString(), searchPattern, RegexOptions.Singleline);
        while (match.Success)
        {
            text.Replace(match.Groups[1].Value, match.Groups[1].Value.ToUpper(), match.Groups[1].Index, match.Groups[1].Length);
            match = match.NextMatch();
        }

        //output
        Console.WriteLine(text);
    }
}
/*
 * Problem 6. String length
 *
 * Write a program that reads from the console a string of maximum 20 characters.
 * If the length of the string is less than 20, the rest of the characters should be filled with *.
 * Print the result string into the console.
 */
class clStringLength
{
    public static void StringLength()
    {
        //input
        //Console.Write("Enter text to censor: ");
        string text = "I'm sorry";    // Console.ReadLine();

        //logic + output
        Console.WriteLine("New text: {0}", text.PadRight(20, '*'));
    }
}
/*
 * Problem 7. Encode/decode
 *
 * Write a program that encodes and decodes a string using given encryption key (cipher).
 * The key consists of a sequence of characters.
 * The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string
 * with the first of the key, the second – with the second, etc. When the last key character is reached,
 * the next is the first.
 */
class clEncodeDecode
{
    public static void EncodeDecode()
    {
        //input
        //Console.Write("Enter text to encode/decode: ");
        StringBuilder text = new StringBuilder(@"We are living in an yellow submarine. We don't have anything else.");    // Console.ReadLine();
        //Console.Write("Enter encoding/decoding cipher: ");
        string cypher = "cypher";               // Console.ReadLine();

        //logic + output
        Console.WriteLine("Original text:\n{0}", text);
        Console.WriteLine("Encoded text:\n{0}", Encode_Decode(text, cypher));
        Console.WriteLine("Decoded text:\n{0}", Encode_Decode(text, cypher));
    }
    static StringBuilder Encode_Decode(StringBuilder input, string cypher)
    {
        for (int i = 0; i < Math.Max(input.Length, cypher.Length); i++)
        {
            input[i] = (char)((int)input[i] ^ (int)cypher[i % cypher.Length]);
        }
        return input;
    }
}
/*
 * Problem 8. Extract sentences
 *
 * Write a program that extracts from a given text all sentences containing given word.
 * Example:
 *  The word is: in
 *  The text is: We are living in a yellow submarine. We don't have anything else.
 *  Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
 *  The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.
 *  Consider that the sentences are separated by . and the words – by non-letter symbols.
 */
class clExtractSentences
{
    public static void ExtractSentences()
    {
        //input
        //Console.Write("Enter text to search for sentences: ");
        StringBuilder text = new StringBuilder(
@"Hey, Jude. Say I'm your number 1. If you want we can travel all the country by train.
She said to me ""You'r not a man"". I think that you have to see this before the summer ends.
Would you help me cross the street, please. Me and my goddamn luck...");    // Console.ReadLine();
        //Console.Write("Enter word to search for: ");
        string word = "you";              // Console.ReadLine();
        string searchPattern = @"[^\.]*?[^a-zA-Z\.]+" + word + @"[^a-zA-Z\.]+[^\.]*?\.";

        //logic
        MatchCollection matches =
            Regex.Matches(text.ToString(), searchPattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        StringBuilder results = new StringBuilder();
        foreach (Match match in matches)
        {
            results.Append(" ");
            results.Append(match.Value.Trim());
        }
        results = new StringBuilder(results.ToString().Trim());

        //output
        Console.WriteLine("Original text:\n{0}", text);
        Console.WriteLine("Found sentences:\n{0}", results);
    }
}
/*
 * Problem 9. Forbidden words
 *
 * We are given a string containing a list of forbidden words and a text containing some of these words.
 * Write a program that replaces the forbidden words with asterisks.
 *
 * Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0
 * and is implemented as a dynamic language in CLR.
 * Forbidden words: PHP, CLR, Microsoft
 * The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0
 * and is implemented as a dynamic language in ***.
 */
class clForbiddenWords
{
    public static void ForbiddenWords()
    {
        //input
        //Console.Write("Enter text to censor: ");
        StringBuilder text = new StringBuilder(
@"Hey, Jude. Say I'm your number 1. If you want we can travel all the country by train.
She said to me ""You'r not a man"". I think that you have to see this before the summer ends.
Would you help me cross the street, please. Me and my goddamn luck...");                            // Console.ReadLine();
        //Console.Write("Enter forbidden words to search for\n(as a list, separated by spaces): ");
        StringBuilder wordList = new StringBuilder("you, think; my+ street, !,luck!");              // Console.ReadLine();

        //logic
        wordList = new StringBuilder(Regex.Replace(wordList.ToString(), @"[^\w]+", "|"));
        wordList = new StringBuilder(wordList.ToString().Trim('|'));
        string wordPattern = "[^a-zA-Z]+(" + wordList + ")[^a-zA-Z]+";

        Match match = Regex.Match(text.ToString(), wordPattern.ToString(), RegexOptions.Singleline | RegexOptions.IgnoreCase);
        while (match.Success)
        {
            Console.WriteLine("censored: {0}", match.Groups[1].Value);
            text = text.Replace(
                match.Groups[1].Value,
                new string('*', match.Groups[1].Value.Length),
                match.Groups[1].Index,
                match.Groups[1].Length
                );
            match = match.NextMatch();
        }

        //output
        Console.WriteLine("Censored text:\n{0}", text);
    }
}
/*
    Problem 10. Unicode characters

    Write a program that converts a string to a sequence of C# Unicode character literals.
    Use format strings.
    Example:
     input   output
     Hi!     \u0048\u0069\u0021
*/
class clUnicodeCharacters
{
    public static void UnicodeCharacters()
    {
        //input
        //Console.Write("Enter text to convert: ");
        string text = @"Hello, C#!";               // Console.ReadLine();

        //logic
        StringBuilder unicodeChars = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            unicodeChars.Append(string.Format(@"\u{0:x4}", (int)text[i]));
        }

        //output
        Console.WriteLine("text: {0}\nunicode chars: {1}", text, unicodeChars);
    }
}
/*
    Problem 11. Format number

    Write a program that reads a number and prints it as a decimal number, hexadecimal number,
    percentage and in scientific notation.
    Format the output aligned right in 15 symbols.
*/
class clFormatNumber
{
    public static void FormatNumber()
    {
        //input
        //Console.Write("Enter a number: ");
        int number = 14567;               // int.Parse(Console.ReadLine());

        //logic

        //output
        Console.WriteLine("{1,-20}{0, 15}", number, "number:");
        Console.WriteLine("{1,-20}{0, 15}", number, "decimal form:");
        Console.WriteLine("{1,-20}{0, 15:x8}", number, "hex form:");
        Console.WriteLine("{1,-20}{0, 15:0%}", number, "percentage form:");
        Console.WriteLine("{1,-20}{0, 15:e}", number, "exponential form:");
    }
}
/*
    Problem 12. Parse URL

    Write a program that parses an URL address given in the format: [protocol]://[server]/[resource]
    and extracts from it the [protocol], [server] and [resource] elements.
    Example:
     URL:
      http://telerikacademy.com/Courses/Courses/Details/212
     Information:
      [protocol] = http
      [server] = telerikacademy.com
      [resource] = /Courses/Courses/Details/212
*/
class clParseURL
{
    public static void ParseURL()
    {
        //input
        //Console.Write("Enter a valid URL address to parse: ");
        //string url = "http://telerikacademy.com";   // Console.ReadLine();
        //string url = "http://telerikacademy.com/";
        string url = "http://telerikacademy.com/Courses/Courses/Details/212";

        //logic
        url = url.Trim();
        string matchPattern = "^([a-zA-Z]+)://([^/]+)(.*)$";
        Match match = Regex.Match(url, matchPattern, RegexOptions.IgnoreCase);

        //output
        if (match.Success)
        {
            Console.WriteLine("URL:        {0}", url);
            Console.WriteLine("[protocol]: {0}", match.Groups[1].Value);
            Console.WriteLine("[base URL]: {0}", match.Groups[2].Value);
            Console.WriteLine("[resource]: {0}", string.IsNullOrEmpty(match.Groups[3].Value) ? "/" : match.Groups[3].Value);
        }
        else
        {
            Console.WriteLine("Non-valid URL");
        }
    }
}
/*
    Problem 13. Reverse sentence

    Write a program that reverses the words in given sentence.
    Example:
     input                                      output
     C# is not C++, not PHP and not Delphi!     Delphi not and PHP, not C++ not is C#!
*/
class clReverseWordsInSentence
{
    public static void ReverseWordsInSentence()
    {
        //input
        //Console.Write("Enter a sentence to reverse: ");
        string sentence = "C# is not C++, not PHP and not Delphi!";   // Console.ReadLine();

        //logic
        string[] wordsList = sentence.Split(
            new char[] { ' ', ',', ':', ';', '!', '?', '.', '"', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(wordsList);
        //Console.WriteLine(string.Join("; ", wordsList));

        string wordPattern = @"[^ ,:;!?\.""()]+";
        string wordPlaceholder = "<word>";
        StringBuilder wordPlaceholders = new StringBuilder(Regex.Replace(sentence, wordPattern, wordPlaceholder));
        //Console.WriteLine(wordPlaceholders);

        Match match = Regex.Match(wordPlaceholders.ToString(), wordPlaceholder);
        for (int i = 0; match.Success; i++)
        {
            wordPlaceholders = wordPlaceholders.Replace(match.Value, wordsList[i], match.Index, match.Length);
            //Console.WriteLine(wordPlaceholders);
            match = Regex.Match(wordPlaceholders.ToString(), wordPlaceholder);
        }

        //output
        Console.WriteLine("Initial sentence: {0}\nReversed sentence: {1}", sentence, wordPlaceholders);
    }
}
/*
    Problem 14. Word dictionary

    A dictionary is stored as a sequence of text lines containing words and their explanations.
    Write a program that enters a word and translates it by using the dictionary.

    Sample dictionary:
     input      output
     .NET       platform for applications from Microsoft
     CLR        managed execution environment for .NET
     namespace  hierarchical organization of classes
*/
class clWordDictionary
{
    public static void WordDictionary()
    {
        //input
        //Console.Write("Enter a word form the dictionary: ");
        string inputWord = "stack";   // Console.ReadLine();

        //logic
        string dictionary = @"
.NET;       platform for applications from Microsoft
CLR;        managed execution environment for .NET
namespace;  hierarchical organization of classes
object;     an instance of a class
string;     C# reference type, used for text processing
stack;      abstract LIFO data structure";

        string searchPattern = string.Format(@"\n{0};\s*(.+)", inputWord);

        Match match = Regex.Match(dictionary, searchPattern);

        //output
        if (match.Success)
        {
            Console.WriteLine("{0}: {1}", inputWord, match.Groups[1].Value);
        }
        else
        {
            Console.WriteLine("{0}: No such word in dictionary", inputWord);
        }
    }
}
/*
    Problem 15. Replace tags

    Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a>
    with corresponding tags [URL=…]…/URL].

    Example:
     input:
      <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course.
      Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
     output:
      <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course.
      Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
*/
class clReplaceTags
{
    public static void ReplaceTags()
    {
        //input
        string inputHTML = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. " +
            "Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        //logic
        string startTagPattern = @"<a\s+href=""([^""]*)"">";
        string startTagReplace = @"[URL=$1]";
        string endTagPattern = @"</a>";
        string endTagReplace = @"[/URL]";

        StringBuilder replacedHTML =
            new StringBuilder(Regex.Replace(inputHTML, startTagPattern, startTagReplace));
        replacedHTML =
            new StringBuilder(Regex.Replace(replacedHTML.ToString(), endTagPattern, endTagReplace));

        //output
        Console.WriteLine(replacedHTML);
    }
}
/*This text contai
    Problem 16. Date difference

    Write a program that reads two dates in the format: day.month.year
    and calculates the number of days between them.

    Example:
     Enter the first date: 27.02.2006
     Enter the second date: 3.03.2006
     Distance: 4 days
*/
class clDateDifference
{
    public static void DateDifference()
    {
        //input
        //Console.Write("Enter the first date (in format day.month.year): ");
        string inputDate = "01.01.2015";              //Console.ReadLine();
        DateTime firstDate = DateTime.Parse(inputDate, new CultureInfo("bg-BG"));

        //Console.Write("Enter the second date (in format day.month.year): ");
        inputDate = "03.01.2015";                     //Console.ReadLine();
        DateTime secondDate = DateTime.Parse(inputDate, new CultureInfo("bg-BG"));

        //logic
        TimeSpan timeInterval = firstDate - secondDate;

        //output
        Console.WriteLine("{1,-15}{0:dd.MM.yyyy}", firstDate, "First date:");
        Console.WriteLine("{1,-15}{0:dd.MM.yyyy}", secondDate, "Second date:");
        Console.WriteLine("{1,-15}{0} days", Math.Abs(timeInterval.Days), "Distance:");
    }
}
/*
    Problem 17. Date in Bulgarian

    Write a program that reads a date and time given in the format: day.month.year hour:minute:second
    and prints the date and time after 6 hours and 30 minutes (in the same format)
    along with the day of week in Bulgarian.
*/
class clDateInBulgarian
{
    public static void DateInBulgarian()
    {
        //config
        Console.OutputEncoding = Encoding.UTF8;

        //input
        //Console.Write("Enter one date and time (in format day.month.year hour:minute:second): ");
        string inputDateTime = "01.01.2015 10:22:00";              //Console.ReadLine();


        //logic
        DateTime dateTime = DateTime.Parse(inputDateTime, new CultureInfo("bg-BG"));
        dateTime = dateTime.AddHours(6.5);

        //output
        Console.WriteLine("{1,-30} {0:dd.MM.yyyy HH:mm:ss}", inputDateTime, "Initial date/time:");
        Console.WriteLine("{1,-30} {0:dd.MM.yyyy HH:mm:ss}", dateTime, "After 6 hours and 30 minutes:");
        Console.WriteLine("{1,-30} {0}", dateTime.ToString("dddd", new CultureInfo("bg-BG")), "Day of week (bg):");
    }
}
/*
    Problem 18. Extract e-mails

    Write a program for extracting all email addresses from given text.
    All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.
*/
class clExtractEMails
{
    public static void ExtractEMails()
    {
        //input
        //Console.Write("Enter text with some e-mails: ");
        string text = @"
This text contains some e-mails, like spinderman@meme.com and MyEmail@dot.dot.tld.
The e-mail Academy@Telerik.com is another way to contact nakov@nakov.info.
Someties e-mails are given like E-mail@153.255.112.79. E-mails may be incorrect like 
IncorrectEmail@200.356.100.10 (invalid IP) or InvalidEmail@nakov.123 (invalid TLD).";              //Console.ReadLine();

        //logic
        string idPattern = @"[^\s0-9]\S*";
        string domainPattern = @"[^\s]+\.[a-zA-Z]{2,}";
        string emailOnDomain = idPattern + "@" + domainPattern;

        string ipPattern = @"([0-9][0-9]?|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.";
        ipPattern = (ipPattern + ipPattern + ipPattern + ipPattern).Trim(new char[] { '\\', '.' });
        string emailOnIp = idPattern + "@" + ipPattern;

        MatchCollection matchesOnDomain = Regex.Matches(text, emailOnDomain);
        MatchCollection matchesOnIp = Regex.Matches(text, emailOnIp);

        //output
        foreach (Match match in matchesOnDomain)
            Console.WriteLine(match.Value);
        foreach (Match match in matchesOnIp)
            Console.WriteLine(match.Value);
    }
}
/*
    Problem 19. Dates from text in Canada

    Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
    Display them in the standard date format for Canada.
*/
class clExtractDatesFromText
{
    public static void ExtractDatesFromText()
    {
        //input
        //Console.Write("Enter text with some dates: ");
        string text = @"
This text contains some dates: 23.02.2015, 24.02.2015, 45.20.1000,
01.01.0001, 00.00.0000, 99.99.9999, 12.08.1997, 30.07.1990, 12.12.1998,
12.12.20023010.02.1000, 10.11.1989.";              //Console.ReadLine();

        //logic
        string datePattern = @"^(\d\d\.\d\d\.\d{4})|\D(\d\d\.\d\d\.\d{4})";
        DateTime dateValue;
        MatchCollection dateMatches = Regex.Matches(text, datePattern);
        //Console.WriteLine(dateMatches.Count);
        foreach (Match date in dateMatches)
        {
            //Console.WriteLine(date.Groups[2].Value);
            if (DateTime.TryParse(date.Groups[2].Value, new CultureInfo("bg-BG"), DateTimeStyles.None, out dateValue))
            {
                Console.WriteLine(dateValue.ToString("g", new CultureInfo("en-CA")));
            }
            /*else
            {
                Console.WriteLine(false);
            }*/
        }
    }
}
/*
    Problem 20. Palindromes

    Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.
*/
class clPalindromes
{
    public static void Palindromes()
    {
        //input
        //Console.Write("Enter text with some palindromes: ");
        string text = @"ABBA, lamal, exe, boababaob, bqlHlqb, alenaFanela, koko";   //Console.ReadLine();

        //logic
        string[] wordsList = text.Split(
            new char[] { ' ', ',', ':', ';', '!', '?', '.', '"', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries);
        bool isPalindrome = true;

        for (int wordIndex = 0; wordIndex < wordsList.Length; wordIndex++)
        {
            for (int charIndex = 0; charIndex < wordsList[wordIndex].Length / 2; charIndex++)
            {
                string word = wordsList[wordIndex];
                if (word[charIndex] != word[word.Length - 1 - charIndex])
                {
                    isPalindrome = false;
                    break;
                }
            }
            Console.WriteLine("{0} {1} palindrome.", wordsList[wordIndex], isPalindrome ? "is" : "is not");
        }
    }
}
/*
    Problem 21. Letters count

    Write a program that reads a string from the console and prints all different letters in the string
    along with information how many times each letter is found.
*/
class clLettersCount
{
    public static void LettersCount()
    {
        //input
        //Console.Write("Enter some text: ");
        string text = @"ABBA, lamal, exe, boababaob, bqlHlqb, alenaFanela, koko";   //Console.ReadLine();

        //logic
        List<char>[] chars = new List<char>[2];
        chars[0] = new List<char>();            //for the chars
        chars[1] = new List<char>();            //for the counts

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                if (!chars[0].Contains(text[i]))
                {
                    chars[0].Add(text[i]);
                    chars[1].Add((char)1);
                }
                else
                {
                    int index = chars[0].IndexOf(text[i]);
                    chars[1][index]++;
                }
            }
        }
        //output
        for (int i = 0; i < chars[0].Count; i++)
        {
            Console.WriteLine("'{0}'x{1}", chars[0][i], (int)chars[1][i]);
        }
    }
}
/*
    Problem 22. Words count

    Write a program that reads a string from the console and lists all different words in the string
    along with information how many times each word is found.
 */
class clWordsCount
{
    public static void WordsCount()
    {
        //input
        //Console.Write("Enter some text: ");
        string text = @"
ABBA, lamal, exe, boababaob, bqlHlqb, alenaFanela, koko,
ABBA, lamal, exe, bqlHlqb, koko,
exe, boababaob, alenaFanela,
lamal, exe, boababaob, koko,
ABBA, lamal, bqlHlqb, alenaFanela";   //Console.ReadLine();

        //logic
        string[] wordsArray = text.Split(
            new char[] { ' ', ',', ':', ';', '!', '?', '.', '"', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries);
        List<List<string>> wordsList = new List<List<string>>();
        wordsList = new List<char>();            //for the chars
        
        //output
    }
}
/*
    Problem 23. Series of letters

    Write a program that reads a string from the console
    and replaces all series of consecutive identical letters with a single one.

    Example:
     input                                          output
     aaaaabbbbbcdddeeeedssaafffhhhhhhhbvndmmmmmm    abcdedsafhbvndm
*/
class clSeriesOfLetters
{
    public static void SeriesOfLetters()
    {
        //input
        //Console.Write("Enter some text: ");
        string text = @"aaaaabbbbbcdddeeeedssaafffhhhhhhhbvndmmmmmm";           //Console.ReadLine();

        //logic
        string result = Regex.Replace(text, @"(.)\1*", @"$1");

        //output
        Console.WriteLine("Initial text: {0}", text);
        Console.WriteLine("Compressed text: {0}", result);
    }
}
/*
    Problem 24. Order words

    Write a program that reads a list of words, separated by spaces
    and prints the list in an alphabetical order.
*/
class clOrderWords
{
    public static void OrderWords()
    {
        //input
        //Console.Write("Enter list of words, separated by spaces: ");
        string text = @"ABBA, lamal, exe, boababaob, bqlHlqb, alenaFanela, koko";   //Console.ReadLine();

        //logic
        string[] wordsList = text.Split(
            new char[] { ' ', ',', ':', ';', '!', '?', '.', '"', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Inital list: {0}", string.Join(", ", wordsList));
        Array.Sort(wordsList);

        //output
        Console.WriteLine("Sorted list: {0}", string.Join(", ", wordsList));
    }
}

class StringsAndTextProcessing
{
    static void Main()
    {
        /*02*/ clReverseString.ReverseString();
        /*03*/ clCorrectBrackets.CorrectBrackets();
        /*04*/ clSubstringInText.SubstringInText();
        /*05*/ clParseTags.ParseTags();
        /*06*/ clStringLength.StringLength();
        /*07*/ clEncodeDecode.EncodeDecode();
        /*08*/ clExtractSentences.ExtractSentences();
        /*09*/ clForbiddenWords.ForbiddenWords();
        /*10*/ clUnicodeCharacters.UnicodeCharacters();
        /*11*/ clFormatNumber.FormatNumber();
        /*12*/ clParseURL.ParseURL();
        /*13*/ clReverseWordsInSentence.ReverseWordsInSentence();
        /*14*/ clWordDictionary.WordDictionary();
        /*15*/ clReplaceTags.ReplaceTags();
        /*16*/ clDateDifference.DateDifference();
        /*17*/ clDateInBulgarian.DateInBulgarian();
        /*18*/ clExtractEMails.ExtractEMails();
        /*19*/ clExtractDatesFromText.ExtractDatesFromText();
        /*20*/ clPalindromes.Palindromes();
        /*21*/ clLettersCount.LettersCount();
        /*22*/ clWordsCount.WordsCount();
        /*23*/ clSeriesOfLetters.SeriesOfLetters();
        /*24*/ clOrderWords.OrderWords();
        /*25*/ //missing
    }
}