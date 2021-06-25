using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models.Tools
{
    public class MPZTopSpeed : Services.Tools.TopSpeedController
    {
        [JsonProperty("personal_best")]
        public TopSpeed personal_best { get; set; }

        [JsonProperty("in_the_year")]
        public TopSpeed in_the_year { get; set; }

        [JsonProperty("in_the_month")]
        public TopSpeed in_the_month { get; set; }

        [JsonProperty("all_in_the_year")]
        public List<TopSpeed> all_in_the_year { get; set; }

        [JsonProperty("all_in_the_month")]
        public List<TopSpeed> all_in_the_month { get; set; }

        [JsonProperty("author")]
        public MPZUser author { get; set; }

        #region OAuth2 User
        public async System.Threading.Tasks.Task ThisUpdateOrCreateBelongOAUser(TopSpeed send_data)
        {
            MPZTopSpeed _data = await UpdateOrCreateAsync(send_data);
            if(_data.personal_best !=null)
            {
                this.personal_best = _data.personal_best;
                this.in_the_year = _data.in_the_year;
                this.in_the_month = _data.in_the_month;
                this.author = _data.author;
            }   
        }
        public async System.Threading.Tasks.Task ThisShowBelongOAUser()
        {
            MPZTopSpeed _data = await ShowAsync();
            if (_data.personal_best != null)
            {
                this.personal_best = _data.personal_best;
                this.in_the_year = _data.in_the_year;
                this.in_the_month = _data.in_the_month;
                this.author = _data.author;
            }
        }
        public async System.Threading.Tasks.Task ThisShowAllBelongOAUser()
        {
            MPZTopSpeed _data = await ShowAllAsync();
            if (_data.personal_best != null)
            {
                this.personal_best = _data.personal_best;
                this.all_in_the_year = _data.all_in_the_year;
                this.all_in_the_month = _data.all_in_the_month;
                this.author = _data.author;
            }
            
        }
        #endregion
        public async System.Threading.Tasks.Task ThisShowAsync(ulong user_id)
        {
            MPZTopSpeed _data = await ShowAsync(user_id);
            if (_data.personal_best != null)
            {
                this.personal_best = _data.personal_best;
                this.in_the_year = _data.in_the_year;
                this.in_the_month = _data.in_the_month;
                this.author = _data.author;
            }
        }
        public async System.Threading.Tasks.Task ThisShowAllAsync(ulong user_id)
        {
            MPZTopSpeed _data = await ShowAllAsync(user_id);
            if (_data.personal_best != null)
            {
                this.personal_best = _data.personal_best;
                this.all_in_the_year = _data.all_in_the_year;
                this.all_in_the_month = _data.all_in_the_month;
                this.author = _data.author;
            }
        }

        public MPZTopSpeed(ulong user_id)
        {
            _ = IntitForOtherUserAsync(user_id);
        }
        
        public MPZTopSpeed(bool isGetTopSpeedDataForOAuthUser = false)
        {
            if(isGetTopSpeedDataForOAuthUser)
            {
                _ = IntitForOAuthUserAsync();
            }
        }
       
        private async System.Threading.Tasks.Task IntitForOAuthUserAsync()
        {
            await ThisShowBelongOAUser();
            await ThisShowAllBelongOAUser();
        }
        private async System.Threading.Tasks.Task IntitForOtherUserAsync(ulong user_id)
        {
            await ThisShowAsync(user_id);
            await ThisShowAllAsync(user_id);
        }
    }
}
