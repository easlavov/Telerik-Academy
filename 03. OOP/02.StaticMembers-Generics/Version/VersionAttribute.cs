using System;

namespace Version
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute : System.Attribute
    {
        private string majorVersion;
        private string minorVersion;

        public VersionAttribute(string majorVersion, string minorVersion)
        {
            this.MajorVersion = majorVersion;
            this.MinorVersion = minorVersion;
        }

        private string MajorVersion
        {
            get { return this.majorVersion; }
            set { this.majorVersion = value; }
        }

        private string MinorVersion
        {
            get { return this.minorVersion; }
            set { this.minorVersion = value; }
        }

        public string Version
        {
            get
            {
                return this.MajorVersion + "." + this.MinorVersion;
            }
        }
    }
}