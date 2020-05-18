using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MissionTracking.Models
{
    public class ActionProgressVM
    {
        public int APID { get; set; }
        public string ActionPoint { get; set; }
        public string Catagory { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string Responsible { get; set; }
        public string Priority { get; set; }
        public string Remarks { get; set; }
        public int? Percentage { get; set; }

    }
}