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

        [HttpGet("{id}")]
        public ActionResult<Computer> Get(int id)
        {
            Computer computer = _computerService.FindById(id);

            if (computer == null)
            {
                return BadRequest();
            }

            return Ok(computer);
        }

        [HttpPost("/api/Computer")]
        public ActionResult<Computer> Post([FromBody] CreateComputer newComputer)
        {
            if (ModelState.IsValid)
            {
                Computer computer = _computerService.Add(newComputer);

                if (computer == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return Created("", computer);
            }

            return BadRequest(newComputer);
        }

        [HttpDelete("{id}")]
        public void DeletePerson(int id)
        {
            if (!_computerService.Remove(id))
            {
                Response.StatusCode = 200;
            }

            Response.StatusCode = 400;
        }

        [HttpGet("/api/Category")]
        public ActionResult<IEnumerable<Category>> GetCategory()
        {
            return Ok(_categoryService.All_2().CategoryList);
        }

    }
}
