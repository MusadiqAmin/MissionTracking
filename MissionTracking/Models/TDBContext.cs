using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MissionTracking.Models
{
    public class TDBContext : DbContext
    {
        public TDBContext() : base("DefaultConnection") { }

        public DbSet<ActionPoints> ActionPoint { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<ISM> ISM { get; set; }
        public DbSet<Files> Files { get; set; }

    }
}