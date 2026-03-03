using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _260303_hw_Json
{
    public class KhLRTRootobject
    {
        public KhLRTData[] Data { get; set; }
        public int ErrorCode { get; set; }
        public string ID { get; set; }
        public object Message { get; set; }
        public bool Success { get; set; }
    }

    public class KhLRTData
    {
        public int Seq { get; set; }
        public string 年 { get; set; }
        public string 月 { get; set; }
        public string 總運量 { get; set; }
        public string 日均運量 { get; set; }
        public string 假日均運量 { get; set; }
        public string 月台上刷卡日均筆數 { get; set; }
        public string 車上刷卡日均筆數 { get; set; }
        public string 售票機日均筆數 { get; set; }
        public string 補票日均筆數 { get; set; }
        public string 團體票日均筆數 { get; set; }
        public string 人工售票日均筆數 { get; set; }
        public string QRCODE日均筆數 { get; set; }
        public string 備註 { get; set; }

    }


    

    

}