using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models.Other.Authorization
{
    public class TokenData
    {
        public string accessToken { get; set; }
        public Token token { get; set; }
    }
    public class Token
    {
        public string id { get; set; }
        public int user_id { get; set; }
        public string client_id { get; set; }
        public string name { get; set; }
        public List<string> scopes { get; set; }
        public bool revoked { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public DateTime expires_at { get; set; }
    }
}
