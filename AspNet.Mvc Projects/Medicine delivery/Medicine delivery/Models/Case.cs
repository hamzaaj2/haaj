using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class Case
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Specialty { get; set; }
        [Required]
        [MaxLength(25)]
        public string Diseases { get; set; }
        [Required]
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        [Required]
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public bool Status { get; set; }
        public string CaseName { get{return Diseases+" - "+Id; } }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public ICollection<MedicineOfPatient> MedicineOfPatient { get; set; }
        public ICollection<MedicalTest> MedicalTest { get; set; }
        public ICollection<OrderMedicineOfPatient> OrderMedicineOfPatient { get; set; }

    }
}