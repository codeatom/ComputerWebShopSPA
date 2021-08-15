using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Repo;
using ComputerWebShopSPA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepo _orderDetailRepo;

        public OrderDetailService(IOrderDetailRepo orderDetailRepo)
        {
            _orderDetailRepo = orderDetailRepo;
        }

        public OrderDetail Add(OrderDetail orderDetail)
        {
            _orderDetailRepo.Create(orderDetail);

            return orderDetail;
        }

        public OrderDetailViewModel All(int orderId)
        {
            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel();
            orderDetailViewModel.OrderDetailList = _orderDetailRepo.Read(orderId);

            return orderDetailViewModel;
        }
    }
}
