using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace PizzExercise.Models
{
    public class ShoppingCart
    {
        PizzaDb pizzaDb = new PizzaDb();

        [Key]
        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            //cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Pizza pizza)
        {
            var cartItem = pizzaDb.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId && c.PizzaId == pizza.PizzaId);

            if (cartItem == null)
            {
                cartItem = new Cart()
                {
                    PizzaId = pizza.PizzaId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                pizzaDb.Carts.Add(cartItem);
            }
            else
            {
                //If the items does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }
            pizzaDb.SaveChanges();
        }

        public int RemoveCart(int id)
        {
            //Get cart
            var cartItem = pizzaDb.Carts.SingleOrDefault(
                cart => cart.CartId == ShoppingCartId && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    pizzaDb.Carts.Remove(cartItem);
                }
                pizzaDb.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = pizzaDb.Carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                pizzaDb.Carts.Remove(cartItem);
            }
            pizzaDb.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return pizzaDb.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            //Get the count of each item un the cart and sum them up
            int? count = (from cartItems in pizzaDb.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply total price by count of that items to get
            // the current price for each of those albums in the cart
            // sum all price totals to get the cart total
            decimal? total = (from cartItems in pizzaDb.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Pizza.Total).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Order userOrder)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            //Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    PizzaId = item.PizzaId,
                    OrderId = userOrder.OrderId,
                    TotalPrice = item.Pizza.Total,
                    Quantity = item.Count

                };
                //Set the order total of the shopping cart
                orderTotal += (item.Count * item.Pizza.Total);
                pizzaDb.OrderDetails.Add(orderDetail);
            }
            //Set the order's total to the orderTotal count
            userOrder.Total = orderTotal;
            //Save the order
            pizzaDb.SaveChanges();
            //Empty the shopping cart
            EmptyCart();
            //Return the orderId as the confirmation number
            return userOrder.OrderId;
        }
        // We're using HttpContextBase to allow access to cookies
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    //Generate a new GUID using Syste.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    //Send tempCartId back to client as cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var shoppingCart = pizzaDb.Carts.Where(c => c.CartId == ShoppingCartId);
            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            pizzaDb.SaveChanges();
        }

    }
}