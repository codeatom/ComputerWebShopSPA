using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ComputerWebShopSPA.Controllers
{
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICategoryService _categoryService;
        private readonly IComputerService _computerService;
        private readonly IShoppingCartService _shoppingCartService;

        public ReactController
            (
            IOrderService orderService,
            IOrderDetailService orderDetailService,
            ICategoryService categoryService,
            IComputerService computerService,
            IShoppingCartService shoppingCartService
            )
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _categoryService = categoryService;
            _computerService = computerService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Computer>> GetComputers()
        {
            return Ok(_computerService.All_2().ComputerList);
        }

        [HttpGet("/api/GetCategories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(_categoryService.All_2().CategoryList);
        }

        [HttpGet("/api/GetOrderedItems/{orderId}")]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderedItems(int orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            orderDetails = _orderDetailService.All(orderId).OrderDetailList;

            return Ok(orderDetails);
        }

        [HttpPost("/api/CreateOrder")]
        public ActionResult<JsonObject> CreateOrder([FromBody] JsonObject jsonObject)
        {
            int orderId = 0;

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

                orderId = _orderService.Add(jsonObject.CreateOrder);
                jsonObject.OrderId = orderId;

                return Created("", jsonObject);
            }

            return BadRequest(jsonObject);
        }

    }
}
