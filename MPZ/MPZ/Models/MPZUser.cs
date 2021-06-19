using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    public class MPZUser
    {
        public uint id { get; set; }
        public string uuid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public object email_verified_at { get; set; }
        public object mfa { get; set; }
        public object phone_verified_at { get; set; }
        public object status { get; set; }
        public object web_site { get; set; }
        public string avatar { get; set; }
        public string locale { get; set; }
        public string flags { get; set; }
        public int public_identity { get; set; }
        public int system { get; set; }
        public int bot { get; set; }
        public MPZSettings settings { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
