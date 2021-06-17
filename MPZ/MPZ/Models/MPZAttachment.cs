using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    public class MPZAttachment
    {
        public ulong id;
        public string uuid;
        public string name;
        public enum AttachmentType { document, photo, file, }
        public AttachmentType type;
        public string path;
        public int size;
        public string author_uuid;
        public MPZUser author;
    }
}
