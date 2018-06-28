using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Model
{
    public class CartModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductUnitPrice { get; set; }

        public int AddedQuantity { get; set; }

        public int FreeQuantity
        {
            get
            {
                int freeQuantity = 0;

                if (this.Product.OfferRules != null && this.Product.OfferRules.Count > 0)
                {
                    int maxOffer = 0;
                    int freeProductCount = 0;

                    foreach (var offerRule in this.Product.OfferRules)
                    {
                        if (offerRule.MinimumProductCount > maxOffer && offerRule.MinimumProductCount <= this.AddedQuantity)
                        {
                            maxOffer = offerRule.MinimumProductCount;
                            freeProductCount = offerRule.FreeProductCount;
                        }
                    }

                    if (maxOffer > 0)
                    {
                        freeQuantity = (this.AddedQuantity / maxOffer) * freeProductCount;
                    }
                }

                return freeQuantity;
            }
        }

        public int TotalQuantity
        {
            get
            {
                return this.AddedQuantity + this.FreeQuantity;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return this.TotalQuantity * this.ProductUnitPrice;
            }
        }

        public decimal DiscountedPrice
        {
            get
            {
                return this.FreeQuantity * this.ProductUnitPrice;
            }
        }

        public decimal FinalPrice
        {
            get
            {
                return this.TotalPrice - this.DiscountedPrice;
            }
        }

        public virtual ProductViewModel Product { get; set; }
    }
}
