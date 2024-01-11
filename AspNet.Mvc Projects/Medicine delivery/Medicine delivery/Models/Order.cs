using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Driver")]
        public string DriverId { get; set; }
        public ICollection<OrderMedicineOfPatient> OrderMedicineOfPatient { get; set; }
        [ForeignKey("StatusOfOrder")]
        public int StatusOfOrderId { get; set; }
        public DateTime? TimeCompleted { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual StatusOfOrder StatusOfOrder { get; set; }

    }
}