using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzExercise.Models
{
    public class Areas
    {
        //This class lists areas that The Pizzatorium delivers to.Enter a few areas,
        //for example, Hatfield, Centurion, Pretoria CBD, Soshanguve.
        //Fields: Area (varchar 25).
        [Key]
        public int AreaId { get; set; }
        [StringLength(25)]
        public string Area { get; set; }
    }
}