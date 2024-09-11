using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_API.Models;

namespace Product_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            this._logger = logger;
        }


        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var product = new List<Product>()
            {
                new Product(){Id=1,ProductName="Computer"},
                new Product(){Id=2,ProductName="Keyboard"},
                new Product(){Id=3,ProductName="Mouse"}
            };
            _logger.LogInformation("GetAllProducts action has been called.");
            return Ok(product);
        }

    }
}
