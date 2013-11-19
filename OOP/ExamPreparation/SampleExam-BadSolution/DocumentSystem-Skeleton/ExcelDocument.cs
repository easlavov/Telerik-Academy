using System;
using System.Linq;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        int? rows;
        int? cols;

        public ExcelDocument(string name)
            : this(name, null, null, null, null, null)
        { }

        public ExcelDocument(string name, string content, int? size, string version, int? rows, int? cols)
        {
            this.Name = name;
            this.Content = content;
            this.Size = size;
            this.Version = version;
            this.Rows = rows;
            this.Cols = cols;            
        }

        public int? Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                this.rows = value;
            }
        }

        public int? Cols
        {
            get
            {
                return this.cols;
            }
            set
            {
                this.cols = value;
            }
        }
    }
}
