using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Data
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ShoppingCartId { get; set; }

        [Required]
        public Computer Computer { get; set; }

        [Required]
        public int Amount { get; set; }
}
}
