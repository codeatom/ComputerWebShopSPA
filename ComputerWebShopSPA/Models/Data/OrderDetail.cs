using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Data
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ComputerId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public Computer Computer { get; set; }

        public Order Order { get; set; }
    }
}
