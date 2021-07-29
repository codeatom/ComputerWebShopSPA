using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerWebShopSPA.Models.Repo;
using ComputerWebShopSPA.Models.Service;
using ComputerWebShopSPA.Models.ViewModel;


namespace ComputerWebShopSPA.Controllers
{
    public class ShoppingCartController : Controller
    {
        //private readonly IComputerRepo _computerRepo;
        private readonly IComputerService _computerService;
        private readonly IShoppingCartService _shoppingCartService;


        public ShoppingCartController(IComputerService computerService, IShoppingCartService shoppingCartService)
        {
            _computerService = computerService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();

            shoppingCartViewModel.ShoppingCart.ShoppingCartItems = _shoppingCartService.GetShoppingCartItems(); ;
            shoppingCartViewModel.ShoppingCartTotal = _shoppingCartService.CartTotalCost();

            return View(shoppingCartViewModel);
        }

        public IActionResult AddToShoppingCart(int computerId)
        {
            var selectedComputer = _computerService.FindById(computerId);

            if(selectedComputer != null)
            {
                _shoppingCartService.AddToCart(selectedComputer, 1);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromShoppingCart(int computerId)
        {
            var selectedComputer = _computerService.FindById(computerId);

            if (selectedComputer != null)
            {
                _shoppingCartService.RemoveFromCart(selectedComputer);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ClearShoppingCart()
        {
            _shoppingCartService.ClearCart();

            return RedirectToAction("Index");
        }

    }
}
