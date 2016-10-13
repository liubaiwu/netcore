using System;

namespace Co.Model
{
    public class AD
    {
        public int? Id{get;set;}
        public bool? IsValid { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
        public int? AdType { get; set; }
        public int? Sort { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShareUrl { get; set; }
        public string IconUrl { get; set; }
        public string ShowStartTime { get; set; }
        public string ShowEndTime { get; set; }
    }
}
