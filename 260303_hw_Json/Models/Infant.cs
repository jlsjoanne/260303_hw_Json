using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _260303_hw_Json
{

    public class InfantRoot
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string totalPage { get; set; }
        public string totalDataSize { get; set; }
        public string page { get; set; }
        public string pageDataSize { get; set; }
        public Infant[] responseData { get; set; }
    }

    public class Infant
    {
        public string statistic_yyy { get; set; }
        public string according { get; set; }
        public string site_id { get; set; }
        public string birth_sex { get; set; }
        public string mother_nation { get; set; }
        public string mother_age { get; set; }
        public string mother_education { get; set; }
        public string birth_count { get; set; }
    }

}