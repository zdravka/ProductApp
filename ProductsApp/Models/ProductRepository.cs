using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository() { 
           Add(new Product{Id = 1 , Name = "Yo Yo", Category = "Toys", Price = 12});
           Add(new Product{Id = 2 , Name = "PS3" , Category = "Toys", Price = 699});
           Add(new Product{Id = 3 , Name = "Asus N56VZ" , Category = "Computers", Price = 2058});
           Add(new Product { Id = 4, Name = "Logitech mouse", Category = "Computers", Price = 30 });
        }

        public IEnumerable<Product> GetAll()
        {
           return products;
        }

        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null) {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p=>p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null) {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1) {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}