using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Repo;
using ComputerWebShopSPA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderService(IOrderRepo orderRepo, IShoppingCartService shoppingCartService, IOrderDetailService orderDetailService)
        {
            _orderRepo = orderRepo;
            _shoppingCartService = shoppingCartService;
            _orderDetailService = orderDetailService;
        }

        public void Add(CreateOrder createOrder)
        {
            Order order = new Order();

            order.FirstName = createOrder.FirstName;
            order.LastName = createOrder.LastName;
            order.Address = createOrder.Address;
            order.City = createOrder.City;
            order.State = createOrder.State;
            order.ZipCode = createOrder.ZipCode;
            order.PhoneNumber = createOrder.PhoneNumber;
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCartService.CartTotalCost();

            _orderRepo.Create(order);

            List<ShoppingCartItem> shoppingCartItemList = _shoppingCartService.GetShoppingCartItems();

            foreach (ShoppingCartItem shoppingCartItem in shoppingCartItemList)
            {
                OrderDetail orderDetail = new OrderDetail();

                orderDetail.OrderId = order.OrderId;
                orderDetail.ComputerId = shoppingCartItem.Computer.Id;
                orderDetail.Computer = shoppingCartItem.Computer;
                orderDetail.Amount = shoppingCartItem.Amount;
                orderDetail.Price = shoppingCartItem.Computer.Price;
                orderDetail.Order = order;

                _orderDetailService.Add(orderDetail);
            }
        }
    }
}
