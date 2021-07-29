using ComputerWebShopSPA.Database;
using ComputerWebShopSPA.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Category Create(Category category)
        {
            _appDbContext.Categories.Add(category);

            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return category;
        }

        public List<Category> Read()
        {
            return _appDbContext.Categories.Include(c => c.ComputerList).ToList();
        }

        public List<Category> Read_2()
        {
            List<Category> categories = _appDbContext.Categories
                .Include(c => c.ComputerList)
                .ToList();

            foreach(Category category in categories)
            {
                category.ComputerList = null;
            }

            return categories;
        }

        public Category Read(int id)
        {
            return _appDbContext.Categories.Include(c => c.ComputerList)
                                          .SingleOrDefault(c => c.Id == id);
        }

        public Category Update(Category category)
        {
            Category originalCategory = Read(category.Id);

            if (originalCategory == null)
            {
                return null;
            }

            _appDbContext.Update(category);

            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return originalCategory;
        }

        public bool Delete(Category category)
        {
            Category originalCategory = Read(category.Id);

            if (originalCategory == null)
            {
                return false;
            }

            _appDbContext.Categories.Remove(originalCategory);

            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}
