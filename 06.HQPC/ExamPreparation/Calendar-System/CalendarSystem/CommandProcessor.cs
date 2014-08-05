namespace CalendarSystem
{
    using System;
    using System.Linq;
    using CalendarSystem.Commands;

    public class CommandProcessor
    {
        private readonly ICalendarEventsManager calendarEventsManager;

        public CommandProcessor(ICalendarEventsManager calendarEventsManager)
        {
            this.calendarEventsManager = calendarEventsManager;
        }

        public string ProcessCommand(CommandParameters parameters)
        {
            ICommand command = null;
            string feedback = string.Empty;
            // First command
            if ((parameters.CommandName == "AddEvent"))
            {
                command = new AddEventCommand(calendarEventsManager, parameters);                
            }
            // Second command
            if ((parameters.CommandName == "DeleteEvents"))
            {
                command = new DeleteEventsCommand(calendarEventsManager, parameters);
            }
            // Third command
            if ((parameters.CommandName == "ListEvents"))
            {
                command = new ListEventsCommand(calendarEventsManager, parameters);
            }

            feedback = command.Execute();

            if (command != null)
            {
                return feedback;
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + parameters.CommandName);
            }
        }
    }
}