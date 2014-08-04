using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem
{
    public interface ICalendarEvent : IComparable<ICalendarEvent>
    {
        DateTime Date { get; set; }

        string Title { get; set; }

        string Location { get; set; }

        string ToString();
    }
}
