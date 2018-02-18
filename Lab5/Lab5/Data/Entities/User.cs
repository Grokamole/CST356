using System;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Data.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public String FirstName { get; set; }

        [StringLength(100)]
        public String MiddleName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public String LastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public String EmailAddress { get; set; }

        [Required]
        [Range(0, 120)]
        public int YearsInSchool { get; set; }

        [Required]
        [Range(0, 4.0)]
        public double GPA { get; set; }
    }
}