using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    class RunTests
    {
        static void Main()
        {
            GSMTest.Run();
            Console.WriteLine();
            GSMCallHistoryTest.Run();
        }
    }
}
