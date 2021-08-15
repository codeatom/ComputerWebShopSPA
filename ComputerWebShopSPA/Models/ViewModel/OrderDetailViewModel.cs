using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.ViewModel
{
    public class OrderDetailViewModel
    {
        public List<OrderDetail> OrderDetailList { get; set; }

        public OrderDetailViewModel()
        {
            OrderDetailList = new List<OrderDetail>();
        }
    }
}
