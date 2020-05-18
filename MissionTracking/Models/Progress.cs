using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionTracking.Models
{
    [Table("Progress")]
    public class Progress
    {

        [Key]
        public int ProgID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReportingDate { get; set; }
        public int Percentage { get; set; }
        public string Status { get; set; }
        public int APID { get; set; }

        public ActionPoints ActionPoints { get; set; }
        public ICollection<Files> Files { get; set; }

    }
} 