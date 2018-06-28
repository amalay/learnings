using Amalay.Business;
using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Amalay.MvcApp.Controllers
{
    public class ProductController : Controller
    {
        IProductManager productManager;
        IOfferRuleManager offerRuleManager;
        IProductOfferRuleManager productOfferRuleManager;

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public ProductController(IProductManager productManager, IOfferRuleManager offerRuleManager, IProductOfferRuleManager productOfferRuleManager)
        {
            this.productManager = productManager;
            this.offerRuleManager = offerRuleManager;
            this.productOfferRuleManager = productOfferRuleManager;
        }
        
        public ActionResult Index()
        {
            return View(this.productManager.GetAllProducts());
        }

        public ActionResult AddItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = this.productManager.GetProduct((int)id);

            if (product == null)
            {
                return HttpNotFound();
            }

            List<CartModel> cartItems = TempData["CartItems"] as List<CartModel>;

            if (cartItems == null)
            {
                cartItems = new List<CartModel>();
            }

            var cartItem = cartItems.SingleOrDefault(i => i.ProductId == product.Id);

            if (cartItem != null)
            {
                cartItem.AddedQuantity += 1;
            }
            else
            {
                cartItem = new CartModel()
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductUnitPrice = product.SellingPrice,
                    AddedQuantity = 1
                };

                cartItems.Add(cartItem);
            }

            cartItem.Product = product;

            TempData["CartItems"] = cartItems;

            return View("Cart", cartItems);
        }

        public ActionResult IncreaseQuantity(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<CartModel> cartItems = TempData["CartItems"] as List<CartModel>;

            if (cartItems != null)
            {
                var cartItem = cartItems.SingleOrDefault(p => p.ProductId == id);

                if (cartItem != null)
                {
                    cartItem.AddedQuantity += 1;
                    TempData["CartItems"] = cartItems;
                }
            }

            return View("Cart", cartItems);
        }

        public ActionResult DecreaseQuantity(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<CartModel> cartItems = TempData["CartItems"] as List<CartModel>;

            if (cartItems != null)
            {
                var cartItem = cartItems.SingleOrDefault(p => p.ProductId == id);

                if (cartItem != null)
                {
                    if (cartItem.AddedQuantity > 1)
                    {
                        cartItem.AddedQuantity -= 1;
                        TempData["CartItems"] = cartItems;
                    }
                    else if (cartItem.AddedQuantity == 1)
                    {
                        return RedirectToAction("RemoveItem", new { id = id });
                    }
                }
            }

            return View("Cart", cartItems);
        }

        public ActionResult RemoveItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<CartModel> cartItems = TempData["CartItems"] as List<CartModel>;

            if (cartItems != null)
            {
                var cartItem = cartItems.SingleOrDefault(p => p.ProductId == id);

                if (cartItem != null)
                {
                    cartItems.Remove(cartItem);
                    TempData["CartItems"] = cartItems;
                }
            }

            return View("Cart", cartItems);
        }
    }
}