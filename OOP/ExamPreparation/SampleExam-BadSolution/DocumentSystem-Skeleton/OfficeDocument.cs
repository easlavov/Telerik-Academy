using System;
using System.Linq;

namespace DocumentSystem
{
    public abstract class OfficeDocument : Binary, IEncryptable
    {
        string version;
        bool isEncrypted;

        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
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
