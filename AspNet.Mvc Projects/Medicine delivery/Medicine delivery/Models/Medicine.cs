using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class Medicine
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(25)]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Generic Name")]
        public string GenericName { get; set; }
        [Required]
        [MaxLength(10)]
        public string Type { get; set; }
        [MaxLength(100)]
        [Display(Name = "How To Use")]
        public string HowToUse { get; set; }
        public ICollection<MedicineOfPatient> MedicineOfPatient { get; set; }
    }
}