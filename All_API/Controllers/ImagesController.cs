using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace All_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllImages()
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
