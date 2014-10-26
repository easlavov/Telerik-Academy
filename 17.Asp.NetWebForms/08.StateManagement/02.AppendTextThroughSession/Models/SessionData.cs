namespace _02.AppendTextThroughSession.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class SessionData
    {
        public SessionData()
        {
            this.Lines = new List<string>();
        }

        public IList<String> Lines { get; set; }
    }
}