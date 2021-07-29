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
    public class HomeController : Controller
    {
        private readonly IComputerService _computerService;

        public HomeController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        public IActionResult Index()
        {
            List<Computer> computersOnSale = new List<Computer>();
            ComputerViewModel computerViewModel = new ComputerViewModel();

            computerViewModel = _computerService.All();

            foreach (Computer computer in computerViewModel.ComputerList)
            {
                if (computer.IsOnSale)
                {
                    computersOnSale.Add(computer);
                }
            }

            computerViewModel.ComputerList = computersOnSale;

            return View(computerViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
