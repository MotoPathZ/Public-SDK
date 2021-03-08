using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    public class MPZNews
    {
        public uint id { get; set; }
        public string uuid { get; set; }
        public string author_id { get; set; }
        public string logo { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string view_count { get; set; }
        public string verification_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public MPZUser author { get; set; }
    }
}
