using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodNStuff.MVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //public string FullName =>$"{FirstName}  {LastName}"; return the value,only when it is get
        [Display(Name ="Full Name")]
        public string FullName 
        {
            get
            {
                return $"{FirstName}  {LastName}";
            }
        }
    }
}