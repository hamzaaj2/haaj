using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class MedicineOfPatient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        [ForeignKey("Case")]
        public int CaseId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Route { get; set; }
        [Required]
        [MaxLength(20)]
        public string Frequency { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string SizeOfMedicine { get; set; }
        public string MedicineName { get { return Name + " " + From+"-"+To+" "; } }
        public virtual Medicine Medicine { get; set; }
        public virtual Case Case { get; set; }
        
    }
}