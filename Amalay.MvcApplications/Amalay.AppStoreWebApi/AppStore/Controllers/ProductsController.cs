using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AppStore.ContextServices;
using AppStore.Models;

namespace AppStore.Controllers
{
    public class ProductsController : ApiController
    {
        private IAppStoreContext dbContext = new AppStoreContext();

        public ProductsController() { }

        public ProductsController(IAppStoreContext context)
        {
            dbContext = context;
        }

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return dbContext.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            //db.Entry(product).State = EntityState.Modified;
            dbContext.MarkAsModified(product);

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

       

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return dbContext.Products.Count(e => e.Id == id) > 0;
        }
    }
}