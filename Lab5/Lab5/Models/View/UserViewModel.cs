using System;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Models.View
{
    public class UserViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [StringLength(100)]
        [Display(Name = "Middle Name")]
        public String MiddleName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Email Address")]
        public String EmailAddress { get; set; }

        [Required]
        [Range(0, 120)]
        [Display(Name = "Years in School")]
        public int YearsInSchool { get; set; }

        [Required]
        [Range(0, 4.0)]
        [Display(Name = "GPA")]
        public double GPA { get; set; }
    }
}