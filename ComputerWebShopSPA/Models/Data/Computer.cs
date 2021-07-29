using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Data
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ComputerSpecs { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public bool IsOnSale { get; set; }

        public bool IsInStock { get; set; }
    }
}
