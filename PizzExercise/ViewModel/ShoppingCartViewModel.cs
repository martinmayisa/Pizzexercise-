using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PizzExercise.Models;

namespace PizzExercise.ViewModel
{
    public class ShoppingCartViewModel
    {
        [Key]
        public int CartId { get; set; }

        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}