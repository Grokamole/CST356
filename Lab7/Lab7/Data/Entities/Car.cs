using System;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Data.Entities
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        public String LicensePlateNumber { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 1)]
        public String Color { get; set; }
    }
}