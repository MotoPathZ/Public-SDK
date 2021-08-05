using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models.Other.Authorization
{
    public class OAuth2Data
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string scope { get; set; }
    }
}
