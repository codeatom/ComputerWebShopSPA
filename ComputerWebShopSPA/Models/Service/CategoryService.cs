using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Repo;
using ComputerWebShopSPA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public Category Add(CreateCategory createCategory)
        {
            Category category = new Category();

            category.Name = createCategory.Name;
            category.Description = createCategory.Description;

            category = _categoryRepo.Create(category);

            return category;
        }

        public CategoryViewModel All()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.CategoryList = _categoryRepo.Read();

            return categoryViewModel;
        }

        public CategoryViewModel All_2()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.CategoryList = _categoryRepo.Read_2();

            return categoryViewModel;
        }

        public List<Category> Categories()
        {
            return _categoryRepo.Read();
        }

        public Category FindById(int id)
        {
            return _categoryRepo.Read(id);
        }

        public Category Edit(int id, CreateCategory createCategory)
        {
            Category originalCategory = FindById(id);

            if (originalCategory == null)
            {
                return null;
            }

            originalCategory.Name = createCategory.Name;
            originalCategory.Description = createCategory.Description;
            originalCategory.ComputerList = createCategory.ComputerList;

            originalCategory = _categoryRepo.Update(originalCategory);

            return originalCategory;
        }

        public CreateCategory CategoryToCreateCategory(Category category)
        {
            CreateCategory createCategory = new CreateCategory();

            createCategory.Name = category.Name;
            createCategory.Description = category.Description;

            return createCategory;
        }

        public bool Remove(int id)
        {
            Category category = _categoryRepo.Read(id);

            if (category != null)
            {
                return _categoryRepo.Delete(category);
            }

            return false;
        }
    }
}
