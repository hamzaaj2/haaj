using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class Driver : IdentityUser
    {
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }
        public string DriverName { get { return FirstName + " " + LastName; } }
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}