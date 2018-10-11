namespace PizzExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Area = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        PizzaId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.PizzaId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        PizzaId = c.Int(nullable: false, identity: true),
                        PizzaPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ingredient1Name = c.String(),
                        Ingredient1Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ingredient2Name = c.String(),
                        Ingredient2Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ingredient3Name = c.String(),
                        Ingredient3Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PizzaSize = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ingredients_IngredientId = c.Int(),
                    })
                .PrimaryKey(t => t.PizzaId)
                .ForeignKey("dbo.Ingredients", t => t.Ingredients_IngredientId)
                .Index(t => t.Ingredients_IngredientId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                        IngredientPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Area = c.String(maxLength: 25),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.DeliveryId);
            
            CreateTable(
                "dbo.DesignViewModels",
                c => new
                    {
                        DesId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DesId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PizzaId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        PaymentMethods = c.String(),
                        Area = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(maxLength: 50),
                        Area = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 10),
                        FavouritePizza = c.String(maxLength: 30),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        MethodOfPayment = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.PizzaSizes",
                c => new
                    {
                        PizzaId = c.Int(nullable: false, identity: true),
                        PizzaSizes = c.String(),
                        PizzaPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PizzaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Carts", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Carts", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.Pizzas", "Ingredients_IngredientId", "dbo.Ingredients");
            DropIndex("dbo.Users", new[] { "Order_OrderId" });
            DropIndex("dbo.Pizzas", new[] { "Ingredients_IngredientId" });
            DropIndex("dbo.Carts", new[] { "Order_OrderId" });
            DropIndex("dbo.Carts", new[] { "PizzaId" });
            DropTable("dbo.PizzaSizes");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.DesignViewModels");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Pizzas");
            DropTable("dbo.Carts");
            DropTable("dbo.Areas");
        }
    }
}
