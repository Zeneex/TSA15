using System;

namespace MobilePhone
{
    class GSMTest
    {
        internal static void Run()
        {
            Console.WriteLine("running GSMTest.Run()" + "\n");

            GSM[] phonesCollection = new GSM[5];
            phonesCollection[0] = new GSM(
                "Nokia",
                "Asha 309",
                90,
                new Person("Gogo", "Penev"),
                new Battery(true, "BL-4U", BatteryType.LithiumIon),
                new Display(240, 400, (uint)ColorCount.ThousandsOfColors)
                );
            phonesCollection[1] = new GSM(
                "Sony",
                "CMD Z7",
                25,
                new Person("Zhoro", "Chanev"),
                new Battery(false, GSM.NA, BatteryType.LithiumPolymer),     //don't switch-on :)
                new Display(96, 92, (uint)ColorCount.Quad)                  //really old
                );
            phonesCollection[2] = new GSM(
                "Nokia",
                "106",
                20,                                                         //≈20 €
                new Person("Bob", "O'Reily"),
                new Battery(false, "BL-5CB", BatteryType.LithiumIon),
                new Display(128, 160, (uint)ColorCount.ThousandsOfColors)   //old
                );
            phonesCollection[3] = new GSM(
                "BlackBerry",
                "Classic",                                      //launched 2014
                380,                                            //≈380 €
                new Person("Mark", "O'"),
                new Battery(true, type: BatteryType.LithiumIon),
                new Display(720, 720, (uint)ColorCount.MillionsOfColors)
                );
            phonesCollection[4] = new GSM(
                "Nokia",
                "XL",
                100,
                new Person("Ella", "McBright", "FedEx"),
                new Battery(true, type: BatteryType.LithiumIon, model: "BN-02"),
                new Display(480, 800, (uint)ColorCount.MillionsOfColors)
                );

            for (int i = 0; i < phonesCollection.Length; i++)
            {
                Console.WriteLine("\nphone {0}:\n\n{1}", i + 1, phonesCollection[i]);
            }
            
            GSM.IPhone4S = new GSM(
                "Apple",
                "iPhone 4S",
                210,
                new Person("Eddy", "Murphy", "Hollywood"),
                new Battery(true, type: BatteryType.LithiumPolymer, model: GSM.NA),
                new Display(640, 960, (uint)ColorCount.MillionsOfColors)
                );

            Console.WriteLine();
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
