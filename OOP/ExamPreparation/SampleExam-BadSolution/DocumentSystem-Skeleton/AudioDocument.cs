using System;
using System.Linq;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        int? samplerate;

        public AudioDocument(string name)
            : this(name, null, null, null, null)
        { }

        public AudioDocument(string name, string content, int? size, int? length, int? samplerate)
        {
            this.Name = name;
            this.Content = content;
            this.Size = size;
            this.Length = length;
            this.Samplerate = samplerate;
        }

        public int? Samplerate
        {
            get
            {
                return this.samplerate;
            }
            set
            {
                this.samplerate = value;
            }
        }
    }
}
