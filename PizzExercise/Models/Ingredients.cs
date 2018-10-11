using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzExercise.Models
{
    public class Ingredients
    {
        [Key]
        [ScaffoldColumn(false)]
        public int IngredientId { get; set; }
        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }
        [Display(Name = "Ingredient Price")]
        public decimal IngredientPrice { get; set; }
    }
}