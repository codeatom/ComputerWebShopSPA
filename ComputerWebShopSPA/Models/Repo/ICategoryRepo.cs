using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public interface ICategoryRepo
    {
        public Category Create(Category category);

        public List<Category> Read();

        public List<Category> Read_2();

        public Category Read(int id);

        public Category Update(Category category);

        public bool Delete(Category category);
    }
}
