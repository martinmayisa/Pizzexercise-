using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PizzExercise.Models;
using PizzExercise.ViewModel;

namespace PizzExercise.Controllers
{
    public class FinalController : Controller
    {
        PizzaDb pizzaDb = new PizzaDb();
        // GET: Final
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            //Set up viewmodel
            var viewModel = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }
        public ActionResult AddToCart(int id)
        {
            //Retrieve the pizza from the database
            var addedPizza = pizzaDb.Pizzas.Single(pizza => pizza.PizzaId == id);
            // Add it to the shoping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedPizza);
            // Go back
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Get the name of the pizza to display confirmation
            int pizzaId = pizzaDb.Carts
                .Single(item => item.RecordId == id).Pizza.PizzaId;
            // Remove from cart
            int itemCount = cart.RemoveCart(id);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(pizzaId.ToString()) +
                          " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/FinalSummary
        [ChildActionOnly]
        public ActionResult FinalSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("FinalSummary");
        }

        public ActionResult AddressAndPayment()
        {
            var areaList = pizzaDb.Area.ToList();
            var payMethod = pizzaDb.PaymentMethods.ToList();
            var viewModel = new FinalizeViewModel()
            {
                PaymentMethods = payMethod,
                Area = areaList
            };
            return View(viewModel);
        }
        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var viewModel = new FinalizeViewModel()
            {
                Shopping = cart.GetCartItems()
            };

            try
            {
                var area = Request.Form["Area"];
                var paymentMethod = Request.Form["PaymentMethods"];

                var current = user;
                var username = current.UserName;
                var order = new Order()
                {
                    Area = area,
                    PaymentMethods = paymentMethod,
                    OrderDate = DateTime.Now,
                    UserName = username,
                    Total = cart.GetTotal()


                };
                //Save order
                pizzaDb.Orders.Add(order);
                pizzaDb.SaveChanges();
                //Process order

                cart.CreateOrder(order);
                return RedirectToAction("Index", "ThankYou", new { viewModel, id = order.OrderId });
            }
            catch
            {
                // Invalid - redisplay with errors
                return View("Error");
            }
        }
    }
}