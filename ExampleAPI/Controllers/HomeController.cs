using Microsoft.AspNetCore.Mvc;
using ExampleAPI.Models;

namespace ExampleAPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {

        //[HttpGet]
        //public ResponseModel GetMessage()
        //{
        //    return new ResponseModel()
        //    {
        //        HttpStatus = 200,
        //        Message = "Hello ASP.NET Core Web API"
        //    };
        //}
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello ASP.NET Core Web API"
            };
            return Ok(result);
        }
    }
}
