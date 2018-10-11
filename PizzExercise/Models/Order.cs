using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzExercise.Models
{
    public class Order
    {
        [Display(Name = "Payment Method")]
        public string PaymentMethods { get; set; }
        [Display(Name = "Delivery Person")]
        public string Area { get; set; }
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public string UserName { get; set; }
        public List<Users> Users { get; set; }
        public List<Cart> Cart { get; set; }
    }
}