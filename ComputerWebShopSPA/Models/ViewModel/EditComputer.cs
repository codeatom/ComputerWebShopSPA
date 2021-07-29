using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.ViewModel
{
    public class EditComputer
    {
        public int Id { get; set; }

        public CreateComputer CreateComputer { get; set; }

        public List<Category> CategoryList { get; set; }

        public EditComputer()
        {
            CategoryList = new List<Category>();
        }
    }
}