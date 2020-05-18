using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionTracking.Models
{
    [Table("Files")]
    public class Files
    {
        [Key]
        public int FID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int? MissionID { get; set; }
        public int? ProgID { get; set; }

        public ISM ISM { get; set; }
        public Progress Progress { get; set; }

    }
}