using System;
using System.Collections.Generic;
using System.Threading;

namespace MobilePhone
{
    class GSMCallHistoryTest
    {
        internal static void Run()
        {
            Console.WriteLine("running GSMCallHistoryTest.Run()" + "\n");

            //create instance
            GSM testPhone = new GSM(
                "Apple",
                "iPhone 4S",
                210,
                new Person("Eddy", "Murphy", "Hollywood"),
                new Battery(true, type: BatteryType.LithiumPolymer, model: GSM.NA),
                new Display(640, 960, (uint)ColorCount.MillionsOfColors)
                );

            Call testCall = new Call("+359 887 563-11/215");    //open and record call
            Thread.Sleep(1000);                                 //simulate call time
            testCall.EndCall();                                 //close last opened call
            testPhone.AddCall(testCall);                        //store the call in history
            testCall = new Call("+359 291 31-74-10");
            Thread.Sleep(1500);
            testCall.EndCall();
            testPhone.AddCall(testCall);
            //create a finished call at once
            testCall = new Call("+359 291 31-74-10/112", new DateTime(2014, 10, 5, 10, 32, 18, 500), 200);
            testPhone.AddCall(testCall);

            //retrieve the history
            List<Call> callHistory = testPhone.CallHistory;

            //print the history
            Console.WriteLine("Print history:\n");
            Console.WriteLine(string.Join("\n\n", callHistory));
            Console.WriteLine();

            //calculate total call cost
            decimal pricePerMinute = 0.37m;
            decimal totalCallPrice = testPhone.CalculateCallPriceTotal(pricePerMinute);

            //print total cost
            Console.WriteLine("Print totals:\n");
            Console.WriteLine("Total call duration: {0} secs", testPhone.TotalCallDuration);
            Console.WriteLine("Call price/minute: {0} Euro", pricePerMinute);
            Console.WriteLine("Total call price: {0} Euro", totalCallPrice);
            Console.WriteLine();

            //retrieve the longest call index
            int longestCallIndex = testPhone.GetLongestCallIndex();

            //print longest call index
            Console.WriteLine("Longest call index: {0}", longestCallIndex);
            Console.WriteLine();

            //remove the longest call from history
            testPhone.DeleteCall(longestCallIndex);
            callHistory = testPhone.CallHistory;        //retrieve again

            //print the history again
            Console.WriteLine("Print history:\n");
            Console.WriteLine(string.Join("\n\n", callHistory));
            Console.WriteLine();

            //purge the history
            testPhone.ClearAllCalls();
            callHistory = testPhone.CallHistory;        //retrieve again

            //print the history again (empty string)
            Console.WriteLine("Print history:\n");
            Console.WriteLine(string.Join("\n\n", callHistory));
            Console.WriteLine();
        }
    }
}
