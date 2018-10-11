using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace PizzExercise.Models
{
    [Bind(Exclude ="OrderId")]
    public class Users
    {       
            /*This model class is used to store user information. 
             * Users have to register before they can order pizza. 
             * Fields: Name (varchar 30), UserName (varchar 30), 
             * Address (varchar 50), Phone (varchar 10), 
             * FavouritePizza (varchar 30).
             */
            [Key]
            public int UserId { get; set; }
            [Required(ErrorMessage = "Name is required")]
            [StringLength(30)]
            public string Name { get; set; }
            [Required(ErrorMessage = "User Name is required")]
            [Display(Name = "User Name")]
            [StringLength(30)]
            public string UserName { get; set; }
            [StringLength(50)]
            public string Address { get; set; }
            [StringLength(50)]
            public string Area { get; set; }
            [Display(Name = "Phone Number")]
            [StringLength(10)]
            public string PhoneNumber { get; set; }
            [StringLength(30)]
            public string FavouritePizza { get; set; }
        
    }
}