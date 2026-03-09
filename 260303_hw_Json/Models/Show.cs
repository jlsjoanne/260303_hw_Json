using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _260303_hw_Json
{


    

    public class Show
    {
        public string version { get; set; }
        public string UID { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public ShowInfo[] showInfo { get; set; }
        public string showUnit { get; set; }
        public string discountInfo { get; set; }
        public string descriptionFilterHtml { get; set; }
        public string imageUrl { get; set; }
        public string[] masterUnit { get; set; }
        public string[] subUnit { get; set; }
        public string[] supportUnit { get; set; }
        public string[] otherUnit { get; set; }
        public string webSales { get; set; }
        public string sourceWebPromote { get; set; }
        public string comment { get; set; }
        public string editModifyDate { get; set; }
        public string sourceWebName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int hitRate { get; set; }
    }

    public class ShowInfo
    {
        public string time { get; set; }
        public string location { get; set; }
        public string locationName { get; set; }
        public string onSales { get; set; }
        public string price { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string endTime { get; set; }
    }


    


}