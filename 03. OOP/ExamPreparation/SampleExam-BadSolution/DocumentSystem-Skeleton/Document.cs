using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        string name;
        string content;

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            protected set
            {
                this.content = value;
            }
        }

        public void LoadProperty(string key, string value)
        {
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        { }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
