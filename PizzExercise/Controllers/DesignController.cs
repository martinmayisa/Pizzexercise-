using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzExercise.Models;
using PizzExercise.ViewModel;

namespace PizzExercise.Controllers
{
    public class DesignController : Controller
    {
        PizzaDb pizzaDb = new PizzaDb();

        //Get: Design/Create
        public ActionResult Create()
        {
            var pizzsSizes = pizzaDb.PizzaSizes.ToList();
            var pizza = pizzaDb.Ingredients.ToList();
            var viewModel = new DesignViewModel()
            {
                PizzaSizes = pizzsSizes,
                Ingredientses = pizza
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Submit(FormCollection collection)
        {
            var pizzasize = Request.Form["PizzaSizes"];
            var ing1 = Request.Form["Ingredient1"];
            var ing2 = Request.Form["Ingredient2"];
            var ing3 = Request.Form["Ingredient3"];
            var pizzaPrice = pizzaDb.PizzaSizes.Where(size => size.PizzaSizes == pizzasize);
            var ingredient1 = pizzaDb.Ingredients.Where(ingredient => ingredient.IngredientName == ing1);
            var ingredient2 = pizzaDb.Ingredients.Where(ingredient => ingredient.IngredientName == ing2);
            var ingredient3 = pizzaDb.Ingredients.Where(ingredient => ingredient.IngredientName == ing3);
            var p = new Pizza()
            {
                PizzaSize = pizzasize,
                Ingredient1Name = ing1,
                Ingredient2Name = ing2,
                Ingredient3Name = ing3
            };
            foreach (var pizzaSize in pizzaPrice)
            {
                p.PizzaPrice = pizzaSize.PizzaPrice;
            }
            foreach (var ingredientse in ingredient1)
            {
                p.Ingredient1Price = ingredientse.IngredientPrice;
            }
            foreach (var ingredientse in ingredient2)
            {
                p.Ingredient2Price = ingredientse.IngredientPrice;
            }
            foreach (var ingredientse in ingredient3)
            {
                p.Ingredient3Price = ingredientse.IngredientPrice;
            }
            p.Total = p.PizzaPrice + p.Ingredient1Price + p.Ingredient2Price + p.Ingredient3Price;

            pizzaDb.Pizzas.Add(p);
            pizzaDb.SaveChanges();
            return RedirectToAction("AddToCart", "Final", new { id = p.PizzaId });
        }
    }
}