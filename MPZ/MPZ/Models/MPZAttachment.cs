using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    public class MPZAttachment
    {
        public ulong id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public enum AttachmentType { document, photo, file, }
        public AttachmentType type { get; set; }
        public string path { get; set; }
        public int size { get; set; }
        public string author_uuid { get; set; }
        public MPZUser author { get; set; }
    }
}
