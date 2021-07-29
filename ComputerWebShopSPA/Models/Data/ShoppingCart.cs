using ComputerWebShopSPA.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Data
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }
    }
}
