using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models.Tools
{
    public class TopSpeed : Services.Tools.TopSpeedController
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public enum TopSpeedType { personal_best, in_the_year, in_the_month }
        public TopSpeedType type;
        public float speed { get; set; }
        public string coordinates { get; set; }
        public float mileage { get; set; }
        public string author_uuid { get; set; }
        public MPZUser author { get; set; }
        public DateTime verified_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
