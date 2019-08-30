using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMVCWebApp.Models
{
    public class Student
    {
        [Display(Name = "Roll")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Student's Name")]
        public string Name { get; set; }
        public string Section { get; set; }
        public string Gender { get; set; }
        public bool IsAMemberOfAnyClub { get; set; }
    }
}