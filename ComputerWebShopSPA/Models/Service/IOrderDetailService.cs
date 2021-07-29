using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public interface IOrderDetailService
    {
        public OrderDetail Add(OrderDetail orderDetail);
    }
}
