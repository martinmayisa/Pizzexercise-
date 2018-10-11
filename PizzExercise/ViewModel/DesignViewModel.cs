using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using PizzExercise.Models;

namespace PizzExercise.ViewModel
{
    public class DesignViewModel
    {
        [Key]
        public int DesId { get; set; }
        public IEnumerable<PizzaSize> PizzaSizes { get; set; }
        public IEnumerable<Ingredients> Ingredientses { get; set; }
    }
}