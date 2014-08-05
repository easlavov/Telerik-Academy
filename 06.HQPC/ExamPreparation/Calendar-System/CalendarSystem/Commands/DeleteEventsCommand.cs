using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Commands
{
    internal class DeleteEventsCommand : ICommand
    {
        private ICalendarEventsManager calendarEventsManager;
        private CommandParameters commandParams;

        public DeleteEventsCommand(ICalendarEventsManager calendarEventsManager, CommandParameters parameters)
        {
            this.calendarEventsManager = calendarEventsManager;
            this.commandParams = parameters;
        }

        public string Execute()
        {
            int eventsDeleted = this.calendarEventsManager.DeleteEventsByTitle(commandParams.Params[0]);

            if (eventsDeleted == 0)
            {
                return "No events found.";
            }

            return eventsDeleted + " events deleted";
        }
    }
}
