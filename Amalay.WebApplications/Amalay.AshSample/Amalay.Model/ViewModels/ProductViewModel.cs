using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Model
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal MRP { get; set; }

        public decimal SellingPrice { get; set; }

        public List<OfferRule> OfferRules { get; set; }

        public string OfferRuleNames
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach (var offerRule in this.OfferRules)
                {
                    sb.Append(offerRule.Name + ", ");
                }

                return sb.ToString().Trim().TrimEnd(',');
            }
        }
    }
}
