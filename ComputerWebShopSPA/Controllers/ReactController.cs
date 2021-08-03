using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Service;
using ComputerWebShopSPA.Models.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Controllers
{
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IComputerService _computerService;
        private readonly IShoppingCartService _shoppingCartService;

        public ReactController(ICategoryService categoryService, IComputerService computerService, IShoppingCartService shoppingCartService)
        {
            _categoryService = categoryService;
            _computerService = computerService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Computer>> Get()
        {
            return Ok(_computerService.All_2().ComputerList);
        }

        [HttpGet("/api/Category")]
        public ActionResult<IEnumerable<Category>> GetCategory()
        {
            return Ok(_categoryService.All_2().CategoryList);
        }

    }
}
