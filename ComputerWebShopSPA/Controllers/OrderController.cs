using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Service;
using ComputerWebShopSPA.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateOrder createOrder = new CreateOrder();
            return View(createOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrder createOrder)
        {
            List<ShoppingCartItem> shoppingCartItems = _shoppingCartService.GetShoppingCartItems();

            if(shoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                _orderService.Add(createOrder);
                return RedirectToAction("OrderComplete");
            }

            return View(createOrder);
        }

        public IActionResult OrderComplete()
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            orderViewModel.ShoppingCartItems = _shoppingCartService.GetShoppingCartItems();
            orderViewModel.TotalCost = _shoppingCartService.CartTotalCost();

            _shoppingCartService.ClearCart();

            return View(orderViewModel);
        }
    }
}
