using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    //OrderMedicineOfPatients
    public class OrderMedicineOfPatient
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Case")]
        public int CaseId { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("MedicineOfPatient")]
        public int MedicineOfPatientId { get; set; }
        public virtual Case Case { get; set; }
        public virtual Order Order { get; set; }
        public virtual MedicineOfPatient MedicineOfPatient { get; set; }  

    }
}