using System;
using System.Linq;

namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        int? framerate;

        public VideoDocument(string name)
            : this(name, null, null, null, null)
        { }

        public VideoDocument(string name, string content, int? size, int? length, int? framerate)
        {
            this.Name = name;
            this.Content = content;
            this.Size = size;
            this.Length = length;
            this.Framerate = framerate;
        }

        public int? Framerate
        {
            get
            {
                return this.framerate;
            }
            set
            {
                this.framerate = value;
            }
        }
    }
}
