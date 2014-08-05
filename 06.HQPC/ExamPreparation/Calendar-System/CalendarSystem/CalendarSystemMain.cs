namespace CalendarSystem
{
    using System;
    using System.Linq;

    class CalendarSystemMain
    {
        internal static void Main()
        {
            var eventsManager = new EventsManagerFast();
            var commandProcessor = new CommandProcessor(eventsManager);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End" || input == null)
                {
                    Environment.Exit(0);
                }

                try
                {
                    var command = CommandParser.Parse(input);
                    string commandResult = commandProcessor.ProcessCommand(command);
                    Console.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }    
}