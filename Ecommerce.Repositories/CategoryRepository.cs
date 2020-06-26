using ECommerce.DatabaseContext;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Repositories
{
    public class CategoryRepository
    {
        private EcommerceDbContext db;

        public CategoryRepository()
        {
            db = new EcommerceDbContext();
        }
        public bool Add(Category category)
        {
            db.Categories.Add(category);

            return db.SaveChanges() > 0;
        }

        public bool Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public Category GetById(int id)
        {
          return db.Categories
                .FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public void LoadProducts(Category category)
        {
            db.Entry(category)
                .Collection(c => c.Products)
                .Query()
                .Where(c => c.IsActive)
                .Load();

        }

    }
}
