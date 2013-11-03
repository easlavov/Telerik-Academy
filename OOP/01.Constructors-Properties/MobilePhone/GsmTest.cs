using System;

namespace MobilePhone
{
    // TASK 7 AND 12
    class GsmTest
    {
        static void Main()
        {
            // TASK 7

            // Create Gsm objects using different constructors
            Gsm firstGsm = new Gsm("1320", "Nokia", 120.50, "Nakov", new Battery("Varta", 336, 12, BatteryType.NiMn), new Display(6, 32));
            Gsm secondGsm = new Gsm("J132", "Sony-Ericson");
            Gsm thirdGsm = new Gsm("Banan", "Plod-Zelenchuk", 50, "Mitko Berbatov", null, null);

            // Initialize a Gsm array
            Gsm[] phones = { firstGsm, secondGsm, thirdGsm };

            // Display information for each Gsm in the array
            foreach (var phone in phones)
            {
                Console.WriteLine(phone.ToString() + Environment.NewLine);
            }

            // Display static property iPhone4S
            Console.WriteLine("STATIC PROPERTY:");
            Console.WriteLine(Gsm.IPhone4S);
            Console.WriteLine("END OF TASK 7. Press any key to start task 12");
            Console.ReadKey();
            Console.WriteLine();
            

            // TASK 12
            Console.WriteLine("TASK 12:" + Environment.NewLine);
            GSMCallHistoryTest.TestCallHistory(); // TASK 12
        }
    }
}
