using Amalay.FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amalay.FoodOrder.ModelViews
{
    public class ShoppingCartViewModel
    {
        [Key]
        public List<Cart> CartItems { get; set; }

        public decimal CartTotal { get; set; }
    }
}