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
    public class ComputersController : Controller
    {
        private readonly IComputerService _computerService;
        private readonly ICategoryService _categoryService;

        public ComputersController(IComputerService computerService, ICategoryService categoryService)
        {
            _computerService = computerService;
            _categoryService = categoryService;
        }

        public IActionResult Index(string name)
        {
            List<Computer> computerList = new List<Computer>();
            string CategoryName;

            if (string.IsNullOrEmpty(name))
            {
                computerList = _computerService.All().ComputerList.OrderBy(c => c.Name).ToList();
                CategoryName = "All Computers";
            }
            else
            {
                computerList = _computerService.All().ComputerList.Where(c => c.Category.Name == name).ToList();
                CategoryName = _categoryService.All().CategoryList.FirstOrDefault(c => c.Name == name)?.Name;
            }

            ComputerViewModel computerViewModel = new ComputerViewModel();
            computerViewModel.ComputerList = computerList;
            computerViewModel.CategoryName = CategoryName;
            
            return View(computerViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateComputer createComputer = new CreateComputer();
            createComputer.CategoryList = _categoryService.All().CategoryList;

            return View(createComputer);
        }

        [HttpPost]
        public IActionResult Create(CreateComputer createComputer)
        {
            if (ModelState.IsValid)
            {
                _computerService.Add(createComputer);
                return RedirectToAction(nameof(Index));
            }

            return View(createComputer);
        }

        public ActionResult Edit(int id)
        {
            Computer computer = _computerService.FindById(id);
            EditComputer editComputer = new EditComputer();

            if (computer == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                editComputer.Id = id;
                editComputer.CategoryList = _categoryService.All().CategoryList;
                editComputer.CreateComputer = _computerService.ComputerToCreateComputer(computer);
            }

            return View(editComputer);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateComputer createComputer)
        {
            EditComputer editComputer = new EditComputer();

            if (ModelState.IsValid)
            {
                _computerService.Edit(id, createComputer);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                editComputer.Id = id;
                editComputer.CreateComputer = createComputer;
            }

            return View(editComputer);
        }

        public IActionResult Details(int id)
        {
            Computer computer = _computerService.FindById(id);

            if (computer == null)
            {
                return RedirectToAction("Index");
            }

            ComputerViewModel computerViewModel = new ComputerViewModel();
            computerViewModel.Computer = computer;

            return View(computerViewModel);
        }

        [HttpGet]
        public ActionResult DeleteRequest(int id)
        {
            ComputerViewModel computerViewModel = new ComputerViewModel();
            computerViewModel.Computer = _computerService.FindById(id);

            return View(computerViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Computer computer = _computerService.FindById(id);
            _computerService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
