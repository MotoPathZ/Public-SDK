using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    class MPZDevlog
    {
        public uint id;
        public string title;
        public string body;
        public List<MPZUser> users;

        public DateTime created_at;
        public DateTime update_at;
    }
}
