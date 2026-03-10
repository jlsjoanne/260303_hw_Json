using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _260303_hw_Json
{
    

    public class GymRootobject
    {
        public Gym[] gymData { get; set; }
    }

    public class Gym
    {
        public int GymID { get; set; }
        public string Name { get; set; }
        public string OperationTel { get; set; }
        public string Address { get; set; }
        public float Rate { get; set; }
        public int RateCount { get; set; }
        public float Distance { get; set; }
        public string GymFuncList { get; set; }
        public string Photo1 { get; set; }
        public string LatLng { get; set; }
        public string RentState { get; set; }
        public string OpenState { get; set; }
        public string Declaration { get; set; }
        public string LandAttrName { get; set; }
    }

}