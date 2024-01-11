using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicine_delivery.Models
{
    public class StatusOfOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}