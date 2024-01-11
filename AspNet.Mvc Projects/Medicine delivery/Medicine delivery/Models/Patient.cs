using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class Patient : IdentityUser
    {
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(10),MinLength(10)]
        public string NationalNumber { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(6)]
        public string Gender { get; set; }
        [Required]
        [MaxLength(10)]
        public string Area { get; set; }
        [Required]
        [MaxLength(10)]
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public string PatientName { get { return FirstName + " " + LastName ; } }
        public string PatientInfo { get { return FirstName + " " + LastName + "-" + NationalNumber; } }
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
        public ICollection<Case> Case { get; set; }

    }
}