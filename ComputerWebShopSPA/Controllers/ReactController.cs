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
    public class ReactController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICategoryService _categoryService;
        private readonly IComputerService _computerService;
        private readonly IShoppingCartService _shoppingCartService;

        public ReactController
            (
            IOrderService orderService,
            ICategoryService categoryService,
            IComputerService computerService,
            IShoppingCartService shoppingCartService
            )
        {
            _orderService = orderService;
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

        [HttpPost("/api/ShoppingCart")]
        public ActionResult<JsonObject> Post([FromBody] JsonObject jsonObject)
        {
            if (jsonObject.ComputerIdList != null && jsonObject.ComputerIdList.Count > 0)
            {
                foreach (var computerId in jsonObject.ComputerIdList)
                {
                    var selectedComputer = _computerService.FindById(computerId);

                    if (selectedComputer != null)
                    {
                        _shoppingCartService.AddToCart(selectedComputer, 1);
                    }
                }

                _orderService.Add(jsonObject.CreateOrder);

                return Created("", jsonObject);
            }

            return BadRequest(jsonObject);
        }
    }
}
