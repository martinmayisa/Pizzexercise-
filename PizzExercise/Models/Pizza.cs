using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzExercise.Models
{
    public class Pizza
    {
        [Key]
        [ScaffoldColumn(false)]
        public virtual int PizzaId { get; set; }
        [Display(Name = "Pizza Price")]
        public virtual decimal PizzaPrice { get; set; }
        [Display(Name = "Ingredient 1 Name")]
        public virtual string Ingredient1Name { get; set; }
        [Display(Name = "Ingredient 1 Price")]
        public virtual decimal Ingredient1Price { get; set; }
        [Display(Name = "Ingredient 2 Name")]
        public virtual string Ingredient2Name { get; set; }
        [Display(Name = "Ingredient 2 Price")]
        public virtual decimal Ingredient2Price { get; set; }
        [Display(Name = "Ingredient 3 Name")]
        public virtual string Ingredient3Name { get; set; }
        [Display(Name = "Ingredient 3 Price")]
        public virtual decimal Ingredient3Price { get; set; }
        public virtual string PizzaSize { get; set; }
        public virtual decimal Total { get; set; }
        public virtual Ingredients Ingredients { get; set; }
    }
}