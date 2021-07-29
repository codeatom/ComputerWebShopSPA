using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.ViewModel
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }

        public List<Category> CategoryList { get; set; }

        public string CategoryName { get; set; }

        public CategoryViewModel()
        {
            CategoryList = new List<Category>();
        }
    }
}
