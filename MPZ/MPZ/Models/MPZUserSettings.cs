using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    public class MPZUserSettings
    {
        public News news { get; set; }
        public Config config { get; set; }

        public class News
        {
            public bool send_news_for_email { get; set; }
            public bool send_news_for_phone { get; set; }
        }

        public class Config
        {
            public string background_color { get; set; }
        }
    }
}
