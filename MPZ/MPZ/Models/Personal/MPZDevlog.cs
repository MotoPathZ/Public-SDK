using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models.Personal
{
    public class MPZDevlog
    {
        public uint id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<MPZUser> users { get; set; }
    }
}
