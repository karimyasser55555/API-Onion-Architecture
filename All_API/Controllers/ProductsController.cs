using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace All_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest("Sorry");
            }

        }
    }
}
