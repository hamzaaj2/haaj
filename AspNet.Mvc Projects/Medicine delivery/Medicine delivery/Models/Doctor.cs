using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class Doctor : IdentityUser
    {
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public string Specialty { get; set; }
        public string DoctorName { get { return FirstName + " " + LastName ; } }
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
        public ICollection<Case> Case { get; set; }

    }
}