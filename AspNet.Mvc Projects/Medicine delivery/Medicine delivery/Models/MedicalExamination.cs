using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class MedicalExamination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MedicalTest> MedicalTest { get; set; }

    }
}