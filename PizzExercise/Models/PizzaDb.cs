using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace PizzExercise.Models
{
    public class PizzaDb:DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Cart> Carts{ get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Areas> Area { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Order> Orders { get; set; }

        public System.Data.Entity.DbSet<PizzExercise.ViewModel.DesignViewModel> DesignViewModels { get; set; }
    }
}