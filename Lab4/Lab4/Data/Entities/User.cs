using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Data.Entities
{
    public class User
    {
        public const int INVALID_USER_ID = -1;

        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; } = INVALID_USER_ID;

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public String FirstName     { get; set; }
        [StringLength(100)]
        [Display(Name = "Middle Name")]
        public String MiddleName    { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public String LastName      { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Email Address")]
        public String EmailAddress  { get; set; }
        [Required]
        [Range(0,120)]
        [Display(Name = "Years in School")]
        public int    YearsInSchool { get; set; }
        [Required]
        [Range(0,4.0)]
        [Display(Name = "GPA")]
        public double GPA           { get; set; }
    }
}
