using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MPZ.Models
{
    public class MPZRole
    {
        public uint id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public Color color { get; set; }
        public MPZRoleSettings settings { get; set; }
        public MPZRoleAccess access { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
    public class MPZRoleSettings
    {

    }
    public class MPZRoleAccess
    {

    }
}
