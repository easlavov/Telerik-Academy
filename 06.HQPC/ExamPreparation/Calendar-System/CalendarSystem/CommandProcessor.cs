namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandProcessor
    {
        private readonly ICalendarEventsManager calendarEventsManager;

        public CommandProcessor(ICalendarEventsManager calendarEventsManager)
        {
            this.calendarEventsManager = calendarEventsManager;
        }

        public ICalendarEventsManager CalendarEventsManager
        {
            get
            {
                return this.calendarEventsManager;
            }
        }

        public string ProcessCommand(Command com)
        {
            // First command
            if ((com.CommandName == "AddEvent") && (com.Params.Length == 2))
            {
                var date = DateTime.ParseExact(com.Params[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new CalendarEvent
                {
                    Date = date,
                    Title = com.Params[1],
                    Location = null,
                };

                this.calendarEventsManager.AddEvent(e);

                return "Event added";
            }

            if ((com.CommandName == "AddEvent") && (com.Params.Length == 3))
            {
                var date = DateTime.ParseExact(com.Params[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new CalendarEvent
                {
                    Date = date,
                    Title = com.Params[1],
                    Location = com.Params[2],
                };

                this.calendarEventsManager.AddEvent(e);

                return "Event added";
            }
            // Second command
            if ((com.CommandName == "DeleteEvents") && (com.Params.Length == 1))
            {
                int c = this.calendarEventsManager.DeleteEventsByTitle(com.Params[0]);

                if (c == 0)
                {
                    return "No events found.";
                }

                return c + " events deleted";
            }
            // Third command
            if ((com.CommandName == "ListEvents") && (com.Params.Length == 2))
            {
                var d = DateTime.ParseExact(com.Params[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var c = int.Parse(com.Params[1]);
                var events = this.calendarEventsManager.CalendarEventsList(d, c).ToList();
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

            throw new Exception("WTF " + com.CommandName + " is?");
        }
    }
}