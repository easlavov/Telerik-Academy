namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICalendarEventsManager
    {
        void AddEvent(CalendarEvent calendarEvent);

        int DeleteEventsByTitle(string eventTitle);

        IEnumerable<CalendarEvent> CalendarEventsList(DateTime date, int count);
    }
}
