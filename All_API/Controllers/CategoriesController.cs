using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.FilterCategories;
using Application.Features.Categories.Queries.GetCategoryDetailes;
using Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace All_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly QenaDbContext context;

        private readonly IMediator Mediator;

        public CategoriesController(IMediator mediator, QenaDbContext context)
        {
            Mediator = mediator;
            this.context = context;
        }
        [HttpGet]
        public IActionResult FillterCategories([FromQuery] FilterCategoriesQuery getAllCategoriesQuery)
        {
            var data = context.Categories;
            var x = data.Where(a => a.Id > 5);
            return Ok(Mediator.Send(getAllCategoriesQuery));
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetCategoryDetails([FromQuery] GetCategoryDetailesQuery getCategoryDetailesQuery)
        {

            return Ok(await Mediator.Send(getCategoryDetailesQuery));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {

            return Ok(await Mediator.Send(createCategoryCommand));
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            return Ok(await Mediator.Send(updateCategoryCommand));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            return Ok(await Mediator.Send(deleteCategoryCommand));
        }
    }
}
