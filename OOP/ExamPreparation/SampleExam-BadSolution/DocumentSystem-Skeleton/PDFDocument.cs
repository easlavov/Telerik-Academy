using System;
using System.Linq;

namespace DocumentSystem
{
    public class PDFDocument : Binary, IEncryptable
    {
        int? pages;
        bool isEncrypted;

        public PDFDocument(string name)
            : this(name, null, null, null)
        { }

        public PDFDocument(string name, string content, int? size, int? pages)
        {
            this.Name = name;
            this.Content = content;
            this.Size = size;
            this.Pages = pages;
        }        

        public int? Pages
        {
            get
            {
                return this.pages;
            }
            set
            {
                this.pages = value;
            }
        }

        public bool IsEncrypted
        {
            get
            {
                return this.isEncrypted;
            }
            set
            {
                this.isEncrypted = value;
            }
        }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
    }
}
