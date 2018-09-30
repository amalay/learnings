using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Model
{
    public class Product : Entity<int>
    {
        [Required]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Maximum retail price")]
        public decimal MRP { get; set; }

        [Required]
        [Display(Name = "Selling price")]
        public decimal SellingPrice { get; set; }
    }

    public class OfferRule : Entity<int>
    {
        [Required]
        [Display(Name = "Rule name")]
        public string Name { get; set; }

        [Display(Name = "Minimum product required to get the Offer")]
        public int MinimumProductCount { get; set; }

        [Display(Name = "Maximum free product")]
        public int FreeProductCount { get; set; }

        [Display(Name = "Discount precentage")]
        public int DiscountPrecentage { get; set; }
    }

    public class ProductOfferRule : Entity<int>
    {
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Display(Name = "OfferRule")]
        public int OfferRuleId { get; set; }        

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("OfferRuleId")]
        public virtual OfferRule OfferRule { get; set; }
    }
}
