using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public interface IShoppingCartService
    {
        public void AddToCart(Computer computer, int amount);

        public int RemoveFromCart(Computer computer);

        public List<ShoppingCartItem> GetShoppingCartItems();

        public void ClearCart();

        public decimal CartTotalCost();
    }
}
