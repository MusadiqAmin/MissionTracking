using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionTracking.Models
{
    [Table("ActionPoints")]
    public class ActionPoints
    {
        [Key]
        public int APID { get; set; }
        public string Catagory { get; set; }
        public string Priority { get; set; }
        public string ActionPoint { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        public string Responsible { get; set; }
        public string Remarks { get; set; }
        public int MissionID { get; set; }

        public ISM ISM { get; set; }
        public ICollection<Progress> Progress { get; set; }


    }
}