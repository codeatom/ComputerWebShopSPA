using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepo _shoppingCartRepo;

        public string ShoppingCartId { get; set; }


        public ShoppingCartService(IShoppingCartRepo shoppingCartRepo, IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            _shoppingCartRepo = shoppingCartRepo;
            ShoppingCartId = cartId;
        }

        public void AddToCart(Computer computer, int amount)
        {
            ShoppingCartItem shoppingCartItem = _shoppingCartRepo.Read(computer, ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Computer = computer,
                    Amount = amount
                };

                _shoppingCartRepo.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _shoppingCartRepo.SaveChanges();
        }

        public int RemoveFromCart(Computer computer)
        {
            ShoppingCartItem shoppingCartItem = _shoppingCartRepo.Read(computer, ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _shoppingCartRepo.Remove(shoppingCartItem);
                }
            }

            _shoppingCartRepo.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _shoppingCartRepo.Read(ShoppingCartId);
        }

        public void ClearCart()
        {
            _shoppingCartRepo.RemoveAll(ShoppingCartId);
            _shoppingCartRepo.SaveChanges();
        }

        public decimal CartTotalCost()
        {
            List<ShoppingCartItem> cartItems = _shoppingCartRepo.Read(ShoppingCartId);

            decimal totalCost = 0;

            foreach (ShoppingCartItem item in cartItems)
            {
                totalCost += item.Computer.Price * item.Amount;
            }

            return totalCost;
        }
    }
}
