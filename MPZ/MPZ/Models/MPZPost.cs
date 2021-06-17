using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    public class MPZPost
    {
        public uint id { get; set; }
        public string uuid { get; set; }
        public string author_uuid { get; set; }
        public string attachments_uuids { get; set; }
        public string body { get; set; }
        public string view_count { get; set; }
        public string verification_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public MPZUser author { get; set; }
        public List<MPZAttachment> attachments { get; set; }
    }
}
