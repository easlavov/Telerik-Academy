using System;

namespace MobilePhone
{
    // TASK 12
    public class GSMCallHistoryTest
    {
        public static void TestCallHistory()
        {
            // Create an instance of the GSM class
            Gsm finalTestGsm = new Gsm("Lumia", "Nokia");

            // Add a few calls
            finalTestGsm.MakeCall("123", 30);
            finalTestGsm.MakeCall("0883-123-456", 124);
            finalTestGsm.MakeCall("0889-123-789", 400);

            // Display information about the calls
            for (int i = 0; i < finalTestGsm.CallHistory.Count; i++)
            {
                Console.WriteLine("Call {0} information:", i + 1);
                Console.WriteLine(finalTestGsm.CallHistory[i] + Environment.NewLine);                
            }

            // Print total price of calls
            Console.WriteLine("Total price of calls: {0}"
                + Environment.NewLine, finalTestGsm.CalculatePrice(0.37));

            // Remove longest call and calculate total price again
            int longestCallIndex = 0;
            int longestCallDuration = 0;
            for (int i = 0; i < finalTestGsm.CallHistory.Count; i++)
            {
                if (finalTestGsm.CallHistory[i].CallDuration > longestCallDuration)
                {
                    longestCallDuration = finalTestGsm.CallHistory[i].CallDuration;
                    longestCallIndex = i;
                }
            }

            finalTestGsm.DeleteCall(longestCallIndex);
            Console.WriteLine("Total price of calls after removal of longest call: {0}"
                + Environment.NewLine, finalTestGsm.CalculatePrice(0.37));

            // Clear call history and print it
            finalTestGsm.ClearCallHistory();
            if (finalTestGsm.CallHistory.Count == 0)
            {
                Console.WriteLine("The call history is empty.");
            }
            else
            {
                for (int i = 0; i < finalTestGsm.CallHistory.Count; i++)
                {
                    Console.WriteLine("Call {0} information:", i + 1);
                    Console.WriteLine(finalTestGsm.CallHistory[i] + Environment.NewLine);
                }
            }            
        }
    }
}
