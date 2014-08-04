namespace CalendarSystem
{
    using System;
    using System.Linq;

    public class CalendarEvent : ICalendarEvent
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        // Fixed bug and a bottleneck
        public int CompareTo(ICalendarEvent calendarEvent)
        {
            int result = DateTime.Compare(this.Date, calendarEvent.Date);

            if (result == 0) // If date is equal
            {
                result = string.Compare(this.Title, calendarEvent.Title);
            }

            if (result == 0) // If date and title are equal
            {
                result = -string.Compare(this.Location, calendarEvent.Location);
            }

            return result;
        }
    }
}
