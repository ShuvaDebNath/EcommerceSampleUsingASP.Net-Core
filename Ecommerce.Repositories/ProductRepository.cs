using ECommerce.DatabaseContext;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Repositories
{
    public class ProductRepository
    {
        private EcommerceDbContext _db;

        public ProductRepository()
        {
            _db = new EcommerceDbContext();
        }

        public bool Add(Product product)
        {
            _db.Products.Add(product);

            return _db.SaveChanges() > 0;
        }

        public bool Remove(Product product)
        {
            _db.Products.Remove(product);
            return _db.SaveChanges() > 0;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public ICollection<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _db.Products.Find(id);
        }

        public bool Update(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;

            return _db.SaveChanges() > 0;
        }
    }
}
