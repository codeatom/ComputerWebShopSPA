using ComputerWebShopSPA.Database;
using ComputerWebShopSPA.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public class ShoppingCartRepo : IShoppingCartRepo
    {
        private readonly AppDbContext _appDbContext;

        public ShoppingCartRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(ShoppingCartItem shoppingCartItem)
        {
            _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
        }

        public ShoppingCartItem Read(Computer computer, string shoppingCartId)
        {
            return _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Computer.Id == computer.Id && s.ShoppingCartId == shoppingCartId);
        }

        public List<ShoppingCartItem> Read(string shoppingCartId)
        {
            return _appDbContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == shoppingCartId)
                .Include(s => s.Computer)
                .ToList();
        }

        public void Remove(ShoppingCartItem shoppingCartItem)
        {
            _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
        }

        public void RemoveAll(string ShoppingCartId)
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
        }

        public bool SaveChanges()
        {
            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}
