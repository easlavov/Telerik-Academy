using System;
using System.Linq;

namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        string charset;

        public TextDocument(string name)
            : this(name, null, null)
        {
        }

        public TextDocument(string name, string charset, string content)
        {
            this.Name = name;
            this.Charset = charset;
            this.Content = content;
        }

        public string Charset
        {
            get
            {
                return this.charset;
            }
            set
            {
                this.charset = value;
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
