using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzExercise.Models;

namespace PizzExercise.ViewModel
{
    public class ThankYouViewModel
    {
        public string Area { get; set; }
        public string PaymentMethods { get; set; }
        public Order Order { get; set; }
        public Users Users { get; set; }
        public Delivery Delivery { get; set; }
        public Pizza Pizza { get; set; }
    }
}