using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzExercise.Models;

namespace PizzExercise.ViewModel
{
    public class UserLoginViewModel
    {
        public Users Users { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
    }
}