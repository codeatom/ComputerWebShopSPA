using ComputerWebShopSPA.Database;
using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Order Create(Order order)
        {
            _appDbContext.Orders.Add(order);

            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return order;
        }
    }
}
