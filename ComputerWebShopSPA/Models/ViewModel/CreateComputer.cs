using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.ViewModel
{
    public class CreateComputer
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string ComputerSpecs { get; set; }

        public Category Category { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public bool IsOnSale { get; set; }

        public bool IsInStock { get; set; }

        public List<Category> CategoryList { get; set; }

        public CreateComputer()
        {
            CategoryList = new List<Category>();
        }


    }
}
