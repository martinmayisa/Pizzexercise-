using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PizzExercise.Models;

namespace PizzExercise.Models
{
    public class PizzaDbContext:DropCreateDatabaseIfModelChanges<PizzaDb>
    {
        protected override void Seed(PizzaDb context)
        {

            new List<PizzaSize>()
            {
                new PizzaSize() { PizzaSizes = "Small", PizzaPrice = 15 },
                new PizzaSize() { PizzaSizes = "Medium", PizzaPrice = 25 },
                new PizzaSize() { PizzaSizes = "Large", PizzaPrice = 40 }
    }.ForEach(ps => context.PizzaSizes.Add(ps));


            new List<Ingredients>
            {
                new Ingredients() { IngredientId = 1, IngredientName = "Cheese", IngredientPrice = 2},
                new Ingredients() { IngredientId = 2, IngredientName = "Capers", IngredientPrice = 3},
                new Ingredients() { IngredientId = 3, IngredientName = "Banana", IngredientPrice = 2,},
                new Ingredients() { IngredientId = 4, IngredientName = "Avacado", IngredientPrice = 4},
                new Ingredients() { IngredientId = 5, IngredientName = "Chicken", IngredientPrice = 5},
                new Ingredients() { IngredientId = 6, IngredientName = "Anchovies", IngredientPrice = 5},
                new Ingredients() { IngredientId = 7, IngredientName = "Sausage", IngredientPrice = 5},
                new Ingredients() { IngredientId = 8, IngredientName = "Mince", IngredientPrice = 6}
}.ForEach(i => context.Ingredients.Add(i));

            new List<Areas>()
            {
                new Areas() { Area = "Hatfield"},
                new Areas() { Area = "Centurion"},
                new Areas() { Area = "Pretoria CBD"},
                new Areas() { Area = "Soshanguve"}
            }.ForEach(a => context.Area.Add(a));

            new List<Delivery>()
            {
                new Delivery() { Name = "Bob", Area = "Hatfield", Photo = "~/Content/Images/bob.gif"},
                new Delivery() { Name = "Jerome", Area = "Centurion", Photo = "~/Content/Images/Jerome.jpg"},
                new Delivery() { Name = "Stacy", Area = "Pretoria CBD", Photo = "~/Content/Images/stacy.jpg"},
                new Delivery() { Name = "Clint", Area = "Soshanguve", Photo = "~/Content/Images/clint.jpg"}
            }.ForEach(p => context.Deliveries.Add(p));

            new List<PaymentMethod>()
            {
                new PaymentMethod() { MethodOfPayment = "Cash"},
                new PaymentMethod() { MethodOfPayment = "Card"},
                new PaymentMethod() { MethodOfPayment = "Paypal"},
                new PaymentMethod() { MethodOfPayment = "Crypto Currency"}
            }.ForEach(p => context.PaymentMethods.Add(p));
            base.Seed(context);
context.SaveChanges();
        }

    }
}