using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodNStuff.MVC.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Product))]//keep the foreign key relation even when the name is changed
        public int ProductID { get; set; }
        public  virtual Product Product{ get; set; } //virtual is a reference, foreign key feature
    }
}