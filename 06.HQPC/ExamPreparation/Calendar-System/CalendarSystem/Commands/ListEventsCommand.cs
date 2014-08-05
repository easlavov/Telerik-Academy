using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Commands
{
    internal class ListEventsCommand : ICommand
    {
        private ICalendarEventsManager calendarEventsManager;
        private CommandParameters commandParams;

        public ListEventsCommand(ICalendarEventsManager calendarEventsManager, CommandParameters parameters)
        {
            this.calendarEventsManager = calendarEventsManager;
            this.commandParams = parameters;
        }

        public string Execute()
        {
            var date = DateTime.ParseExact(commandParams.Params[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var count = int.Parse(commandParams.Params[1]);
            var events = this.calendarEventsManager.CalendarEventsList(date, count).ToList();
            var sb = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var e in events)
            {
                sb.AppendLine(e.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
