using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PizzExercise.Models;
using PizzExercise.ViewModel;


namespace PizzExercise.Controllers
{
    [Authorize]
    public class ThankyouController : Controller
    {
        PizzaDb pizzaDb = new PizzaDb();
        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        // GET: Thankyou
        public ActionResult Index(FinalizeViewModel model, int id)
        {
            //Validate customer owns this order
            var order = pizzaDb.Orders.Single(o => o.OrderId == id);
            var pizza = pizzaDb.Pizzas.Single(o => o.PizzaId == id);
            var current = user;
            var username = current.UserName;

            bool isValid = pizzaDb.Orders.Any(
                o => o.OrderId == order.OrderId && o.UserName == username);

            var deliveryPerson = pizzaDb.Deliveries.SingleOrDefault(d => d.Area == order.Area);
            var userPerson = pizzaDb.Users.SingleOrDefault(p => p.Name == order.UserName);

            if (isValid)
            {
                var viewModel = new ThankYouViewModel()
                {
                    Area = order.Area,
                    Order = order,
                    Delivery = deliveryPerson,
                    Users = userPerson,
                    Pizza = pizza

                };
                return View(viewModel);
            }
            else
            {
                return View("Error");
            }
        }
    }
}