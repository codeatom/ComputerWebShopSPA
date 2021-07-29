using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public interface ICategoryService
    {
        public Category Add(CreateCategory createCategory);

        public CategoryViewModel All();

        public CategoryViewModel All_2();

        public List<Category> Categories();

        public Category FindById(int id);

        public Category Edit(int id, CreateCategory createCountry);

        public CreateCategory CategoryToCreateCategory(Category category);

        public bool Remove(int id);
    }
}
