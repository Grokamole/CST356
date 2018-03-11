using System;
using System.ComponentModel.DataAnnotations;

namespace Lab8.Models.View
{
    public class CarViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        [Display(Name="License Plate Number")]
        public String LicensePlateNumber { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 1)]
        [Display(Name ="Color")]
        public String Color { get; set; }

        public int UserID { get; set; }
    }
}
