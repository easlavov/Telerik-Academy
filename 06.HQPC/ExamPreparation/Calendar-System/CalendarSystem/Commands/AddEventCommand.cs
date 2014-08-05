using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Commands
{
    internal class AddEventCommand : ICommand
    {
        private ICalendarEventsManager calendarEventsManager;
        private CommandParameters commandParams;

        public AddEventCommand(ICalendarEventsManager calendarEventsManager, CommandParameters parameters)
        {
            this.calendarEventsManager = calendarEventsManager;
            this.commandParams = parameters;
        }

        public string Execute()
        {
            var date = DateTime.ParseExact(commandParams.Params[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string title = commandParams.Params[1];
            string location;
            if (commandParams.Params.Length == 3)
            {
                location = commandParams.Params[2];
            }
            else
            {
                location = null;
            }

            var calendarEvent = new CalendarEvent
            {
                Date = date,
                Title = title,
                Location = location,
            };

            this.calendarEventsManager.AddEvent(calendarEvent);

            return "Event added";
        }
    }
}
