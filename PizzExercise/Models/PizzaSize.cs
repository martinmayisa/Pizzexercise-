using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzExercise.Models
{
    public class PizzaSize
    {
        [Key]
        public int PizzaId { get; set; }
        [Display(Name = "Pizza Size")]
        public string PizzaSizes { get; set; }
        [Display(Name = "Pizza Price")]
        public decimal PizzaPrice { get; set; }
    }
}