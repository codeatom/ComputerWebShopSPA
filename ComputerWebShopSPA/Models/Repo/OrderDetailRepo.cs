using ComputerWebShopSPA.Database;
using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        private readonly AppDbContext _appDbContext;

        public OrderDetailRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public OrderDetail Create(OrderDetail orderDetail)
        {
            _appDbContext.OrderDetails.Add(orderDetail);

            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return orderDetail;
        }
    }
}
