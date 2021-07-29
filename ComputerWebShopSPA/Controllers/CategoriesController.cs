using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Service;
using ComputerWebShopSPA.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IComputerService _computerService;

        public CategoriesController(ICategoryService categoryService, IComputerService computerService)
        {
            _categoryService = categoryService;
            _computerService = computerService;
        }

        public IActionResult Index()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel = _categoryService.All();

            return View(categoryViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCategory createCategory = new CreateCategory();
            return View(createCategory);
        }

        [HttpPost]
        public IActionResult Create(CreateCategory createCategory)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(createCategory);
                return RedirectToAction(nameof(Index));
            }

            return View(createCategory);
        }

        public ActionResult Edit(int id)
        {
            Category category = _categoryService.FindById(id);
            EditCategory editCategory = new EditCategory();

            if (category == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                editCategory.Id = id;
                editCategory.CreateCategory = _categoryService.CategoryToCreateCategory(category);
            }

            return View(editCategory);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateCategory createCategory)
        {
            EditCategory editCategory = new EditCategory();

            if (ModelState.IsValid)
            {
                _categoryService.Edit(id, createCategory);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                editCategory.Id = id;
                editCategory.CreateCategory = createCategory;
            }

            return View(editCategory);
        }

        [HttpGet]
        public ActionResult DeleteRequest(int id)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Category = _categoryService.FindById(id);

            return View(categoryViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = _categoryService.FindById(id);

            if (category.ComputerList.Count == 0)
            {
                _categoryService.Remove(id);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
