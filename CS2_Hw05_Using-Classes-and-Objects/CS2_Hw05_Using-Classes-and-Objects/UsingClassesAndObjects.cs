using System;

class HelperMethods
{
    public static double ToRadians(double degAngle)
    {
        return degAngle * Math.PI / 180;
    }

    public static double ToDegrees(double radAngle)
    {
        return radAngle * 180 / Math.PI;
    }
}

class UsingClassesAndObjects
{
    /*
     * Problem 1. Leap year
     *
     * Write a program that reads a year from the console and checks whether it is a leap one.
     * Use System.DateTime.
     */
    static void LeapYear()
    {
        Console.Write("Check wether the year is leap one: ");
        Console.WriteLine("{0}",
            DateTime.IsLeapYear(int.Parse(Console.ReadLine())) ? "Leap" : "Non-leap");
    }
    /*
     * Problem 2. Random numbers
     *
     * Write a program that generates and prints to the console 10 random values in the range [100, 200].
     */
    static void RandomNumbers()
    {
        Random randomGenerator = new Random();
        int lowerBound = 100;
        int upperBound = 200;
        int count = 10;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(randomGenerator.Next(lowerBound, upperBound + 1));
        }
    }
    /*
     * Problem 3. Day of week
     *
     * Write a program that prints to the console which day of the week is today.
     * Use System.DateTime.
     */
    static void DayOfWeek()
    {
        DateTime currentDate = DateTime.Now;
        Console.WriteLine("Today is {0}", currentDate.DayOfWeek);
    }
    /*
     * Problem 4. Triangle surface
     *
     * Write methods that calculate the surface of a triangle by given:
     *     Side and an altitude to it;
     *     Three sides;
     *     Two sides and an angle between them;
     * Use System.Math.
     */
    static void TriangleSurface(float sideA, float sideOrAltitude, float sideC = -1f, double angle = -1f)
    {
        if (sideA < 0 || sideOrAltitude < 0)
        {
            return;                             //sides must be non-negative
        }

        double area = new double();

        if (sideC == -1f && angle == -1f)       // => area(side, altitude)
        {
            area = (sideA * sideOrAltitude) / 2;

            //output
            Console.WriteLine("S_triangle(a = {0:0.###}, h = {1:0.###}) = {2:0.###}",
                sideA, sideOrAltitude, area);
        }
        else if (sideC >= 0f && angle == -1f)   // => area(side, side, side)
        {
            //p is triangle's semiperimeter
            double p = (sideA + sideOrAltitude + sideC) / 2;
            //Heron's formula for calculation the area of a triangle when all 3 sizes are given
            area = Math.Sqrt(p * (p - sideA) * (p - sideOrAltitude) * (p - sideC));

            //output
            Console.WriteLine("S_triangle(a = {0:0.###}, b = {1:0.###}, c = {2:0.###}) = {3:0.###}",
                sideA, sideOrAltitude, sideC, area);
        }
        else if (sideC == -1f && angle >= 0f && angle <= 180)   // => area(side, side, angle)
        {
            area = sideA * sideOrAltitude * Math.Sin(angle) / 2;

            //output
            Console.WriteLine("S_triangle(a = {0:0.###}, b = {1:0.###}, α = {2:0.###}°) = {3:0.###}",
                sideA, sideOrAltitude, HelperMethods.ToDegrees(angle), area);
        }

    }
    /*
     * Problem 5. Workdays
     *
     * Write a method that calculates the number of workdays between today and given date, passed as parameter.
     * Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
     */
    static void Workdays(DateTime givenDate)
    {
        DateTime startDate = givenDate;
        DateTime endDate = DateTime.Today;

        if (startDate > endDate)
        {
            startDate = DateTime.Today;
            endDate = givenDate;
        }

        DateTime[] publicHolidays =
        {
            new DateTime(1, 1, 1),      //Нова година
            new DateTime(1, 3, 3),      //Ден на Освобождението на България от османско робство
            //Възкресение Христово не е включено в датите на празниците поради неспособност на автора да
            //намери/създаде ясен и точен алгоритъм за изчислението на датата, тъй като празника е "подвижен".
            //Също така авторът няма достатъчно познания за календарите и техните подробности, на които се базира
            //изчислението на датата на Великден.
            new DateTime(1, 5, 1),      //Ден на труда
            new DateTime(1, 5, 6),      //Ден на храбростта и Българската армия 
            new DateTime(1, 9, 22),     //Ден на независимостта на България 
            new DateTime(1, 12, 24),    //Коледа
            new DateTime(1, 12, 25),    //Коледа
            new DateTime(1, 12, 26),    //Коледа
            new DateTime(1, 12, 31)     //Нова година
        };

        long dayCount = 0;
        long workDayCount = 0;
        bool isWorkDay;

        while (startDate.AddDays(dayCount) <= endDate)        //inclusive date span
        {
            isWorkDay = true;
            if (startDate.AddDays(dayCount).DayOfWeek != System.DayOfWeek.Saturday
                && startDate.AddDays(dayCount).DayOfWeek != System.DayOfWeek.Sunday)
            {
                foreach (DateTime publicHoliday in publicHolidays)
                {
                    if (publicHoliday.Day == startDate.AddDays(dayCount).Day
                        && publicHoliday.Month == startDate.AddDays(dayCount).Month)
                    {
                        isWorkDay = false;
                        break;
                    }
                }
                if (isWorkDay)
                {
                    workDayCount++;
                }
            }
            dayCount++;
        }

        Console.WriteLine("form {0:dd.MM.yyyy} to {1:dd.MM.yyyy} there is {2} days and {3} workdays (incl.)",
            startDate, endDate, dayCount, workDayCount);
    }
    /*
     * Problem 6. Sum integers
     *
     * You are given a sequence of positive integer values written into a string, separated by spaces.
     * Write a function that reads these values from given string and calculates their sum.
     *
     * Example:
     * input                output
     * "43 68 9 23 318"     461
     */
    static void SumIntegers(string inputSequence)
    {
        long sum = 0;
        foreach( string value in inputSequence.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries) )
            sum += int.Parse(value);

        Console.WriteLine(sum);
    }

    static void Main()
    {
        //LeapYear();
        //RandomNumbers();
        //DayOfWeek();

        //float sideA = 3f;
        //float sideB = 5f;
        //float sideC = 4.5f;
        //float heightA = 8.8f;
        //float degAngle = 30;    // 30° ≈ 0.524 rad
        //float radAngle = 3;     // 3 rad ≈ 171.887°

        //TriangleSurface(sideA, heightA);
        //TriangleSurface(sideA, sideB, sideC: sideC);
        //TriangleSurface(sideA, sideB, angle: HelperMethods.ToRadians(degAngle));
        //TriangleSurface(sideA, sideB, angle: radAngle);
        //TriangleSurface(-1, -1, angle: radAngle);       //doesn't return

        //Workdays(new DateTime(2015, 1, 1));

        SumIntegers("43 68 9 23 318");      //sum = 461
        SumIntegers("10 10 10 10 10");      //sum = 50
        SumIntegers("501 349 21 954 7");    //sum = 1832
    }
}