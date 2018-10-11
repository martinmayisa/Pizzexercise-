using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzExercise.Models;

namespace PizzExercise.ViewModel
{
    public class FinalizeViewModel
    {
        public IEnumerable<Areas> Area { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
        public Order Order { get; set; }
        public List<Cart> Shopping { get; set; }
        public Users Users { get; set; }
        public Delivery Delivery { get; set; }
    }
}