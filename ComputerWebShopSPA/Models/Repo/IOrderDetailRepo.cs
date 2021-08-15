using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public interface IOrderDetailRepo
    {
        public OrderDetail Create(OrderDetail orderDetail);

        public List<OrderDetail> Read(int orderId);
    }
}
