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
                string ct = Console.ReadLine();
                if (ct == "End" || ct == null)
                {
                    goto end;
                }

                try
                {
                    // The sequence of commands is finished
                    Console.WriteLine(commandProcessor.ProcessCommand(Command.Parse(ct)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            end:
            {
            }
        }
    }    
}