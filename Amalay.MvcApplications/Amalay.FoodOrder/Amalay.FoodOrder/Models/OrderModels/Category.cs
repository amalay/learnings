using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amalay.FoodOrder.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Catagory Id")]
        public int ID { get; set; }

        [DisplayName("Catagory")]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}