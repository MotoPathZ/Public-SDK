using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    public class MPZUser : Services.UserController
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


        public MPZUser(string _uuid)
        {
            _ = InitAsync(_uuid);
        }
        public MPZUser()
        {
            //For create MPZ User and null var...
        }
        private async System.Threading.Tasks.Task InitAsync(string uuid)
        {
            MPZUser _user = await ShowAsync(uuid);
            this.id = _user.id;
            this.uuid = _user.uuid;
            this.firstname = _user.firstname;
            this.lastname = _user.lastname;
            this.username = _user.username;
            this.email = _user.email;
            this.phone = _user.phone;
            this.email_verified_at = _user.email_verified_at;
            this.mfa = _user.mfa;
            this.phone_verified_at = _user.phone_verified_at;
            this.status = _user.status;
            this.web_site = _user.web_site;
            this.avatar = _user.avatar;
            this.locale = _user.locale;
            this.flags = _user.flags;
            this.public_identity = _user.public_identity;
            this.system = _user.system;
            this.bot = _user.bot;
            this.settings = _user.settings;
            this.created_at = _user.created_at;
            this.updated_at = _user.updated_at;
        }
        public async System.Threading.Tasks.Task UpdateAsync(MPZUser updateData)
        {
            MPZUser _user = await UpdateAsync(uuid, updateData);
            this.id = _user.id;
            this.uuid = _user.uuid;
            this.firstname = _user.firstname;
            this.lastname = _user.lastname;
            this.username = _user.username;
            this.email = _user.email;
            this.phone = _user.phone;
            this.email_verified_at = _user.email_verified_at;
            this.mfa = _user.mfa;
            this.phone_verified_at = _user.phone_verified_at;
            this.status = _user.status;
            this.web_site = _user.web_site;
            this.avatar = _user.avatar;
            this.locale = _user.locale;
            this.flags = _user.flags;
            this.public_identity = _user.public_identity;
            this.system = _user.system;
            this.bot = _user.bot;
            this.settings = _user.settings;
            this.created_at = _user.created_at;
            this.updated_at = _user.updated_at;
        }
    }
}
