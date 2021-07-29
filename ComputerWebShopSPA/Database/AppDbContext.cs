using ComputerWebShopSPA.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Database
{
    public class AppDbContext : IdentityDbContext<IdentityAppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Computer> Computers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
