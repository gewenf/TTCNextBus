namespace FinalGroupProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public int StopID { get; set; }
    }
}
