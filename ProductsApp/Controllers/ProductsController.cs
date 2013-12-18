using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            return repository.GetAll();
        }

        // GET api/<controller>/5
        //Install-Package Microsoft.AspNet.WebApi.SelfHost -Pre
        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Product> GetProductByCategory(string category) {
            return repository.GetAll().Where(p => string.Equals(p.Category,category,StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostProduct(Product item) {
            item = repository.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { Id = item.Id });
            return response;
        }

        public void PutProduct(int id, Product item) {
            item.Id = id;
            if (!repository.Update(item)) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
      
        public void DeleteProduct(int id) {
            Product item = repository.Get(id);
            if (item == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }

    }
}