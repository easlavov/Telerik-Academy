using System;
using System.Linq;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEditable
    {
        int? chars;

        public WordDocument(string name)
            : this(name, null, null, null, null)
        { }

        public WordDocument(string name, string content, int? size, string version, int? chars)
        {
            this.Name = name;
            this.Content = content;
            this.Size = size;
            this.Version = version;
            this.Chars = chars;
        }

        public int? Chars
        {
            get
            {
                return this.chars;
            }
            set
            {
                this.chars = value;
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
