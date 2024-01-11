using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class Admin : IdentityUser
    {
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
    }
}