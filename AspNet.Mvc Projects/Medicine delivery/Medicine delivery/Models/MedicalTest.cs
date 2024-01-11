using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class MedicalTest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("MedicalExamination")]
        public int MedicalExaminationId { get; set; }
        [ForeignKey("Case")]
        public int CaseId { get; set; }
        public string Note { get; set; }
        [Display(Name = "Upload Medical Test")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public DateTime? UploadTime { get; set; }
        public bool UploadTest { get; set; }
        public virtual MedicalExamination MedicalExamination { get; set; }
        public virtual Case Case { get; set; }


    }
}