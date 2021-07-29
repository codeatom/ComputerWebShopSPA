using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public interface IShoppingCartRepo
    {
        public ShoppingCartItem Read(Computer computer, string shoppingCartId);

        public List<ShoppingCartItem> Read(string ShoppingCartId);

        public void Add(ShoppingCartItem shoppingCartItem);

        public void Remove(ShoppingCartItem shoppingCartItem);

        public void RemoveAll(string ShoppingCartId);

        public bool SaveChanges();
    }
}
