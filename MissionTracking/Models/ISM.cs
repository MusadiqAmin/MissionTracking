using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionTracking.Models
{
    [Table("ISM")]
    public class ISM
    {

        [Key]
        public int MissionID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MStartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MEndDate { get; set; }
        public string Program { get; set; }
        public string Type { get; set; }
        public string Rating { get; set; }


        public ICollection<ActionPoints> ActionPoints { get; set; }
        public ICollection<Files> Files { get; set; }


    }
}