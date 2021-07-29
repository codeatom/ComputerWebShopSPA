using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public interface IOrderService
    {
        void Add(CreateOrder createOrder);
    }
}
