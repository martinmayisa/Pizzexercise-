using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzExercise.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Area { get; set; }
        public string Photo { get; set; }
    }
}