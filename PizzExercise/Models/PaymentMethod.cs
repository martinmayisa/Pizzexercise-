using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzExercise.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentId { get; set; }
        [Required(ErrorMessage = "Payment method is required")]
        [Display(Name = "Method of Payment")]
        public string MethodOfPayment { get; set; }
    }
}