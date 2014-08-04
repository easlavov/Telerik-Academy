namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManagerFast : ICalendarEventsManager
    {
        private MultiDictionary<string, CalendarEvent> calendarEvents;
        private OrderedMultiDictionary<DateTime, CalendarEvent> orderedCalendarEvents;

        public EventsManagerFast()
            : this(
                new MultiDictionary<string, CalendarEvent>(true),
                new OrderedMultiDictionary<DateTime, CalendarEvent>(true))
        {
        }

        public EventsManagerFast(
                MultiDictionary<string, CalendarEvent> calendarEvents,
                OrderedMultiDictionary<DateTime, CalendarEvent> orderedCalendarEvents)
        {
            this.calendarEvents = calendarEvents;
            this.orderedCalendarEvents = orderedCalendarEvents;
        }

        public void AddEvent(CalendarEvent calendarEvent)
        {
            string eventTitleLowerCase = calendarEvent.Title.ToLowerInvariant();
            this.calendarEvents.Add(eventTitleLowerCase, calendarEvent);
            this.orderedCalendarEvents.Add(calendarEvent.Date, calendarEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleToLowercase = title.ToLowerInvariant();
            var calendarEventsByTitle = this.calendarEvents[titleToLowercase];
            int calendarEventsToBeDeletedCount = calendarEventsByTitle.Count;

            foreach (var calendarEvent in calendarEventsByTitle)
            {
                this.orderedCalendarEvents.Remove(calendarEvent.Date, calendarEvent);
            }

            this.calendarEvents.Remove(titleToLowercase);

            return calendarEventsToBeDeletedCount;
        }

        public IEnumerable<CalendarEvent> CalendarEventsList(DateTime date, int count)
        {
            var calendarEventsByDate = this.orderedCalendarEvents.RangeFrom(date, true).Values.Take(count);

            return calendarEventsByDate;
        }
    }
}
