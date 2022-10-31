namespace FinalGroupProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NextBusEntities : DbContext
    {
        public NextBusEntities()
            : base("name=NextBusEntities")
        {
        }

        public virtual DbSet<UserRecord> UserRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
