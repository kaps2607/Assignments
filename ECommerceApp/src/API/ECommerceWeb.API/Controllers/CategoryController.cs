using ECommerceWeb.Application.Features.CategoryFeature.Command.AddCategory;
using ECommerceWeb.Application.Features.CategoryFeature.Command.DeleteCategory;
using ECommerceWeb.Application.Features.CategoryFeature.Query.GetAllCategories;
using ECommerceWeb.Application.Features.CategoryFeature.Query.GetCategoryById;
using ECommerceWeb.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.API.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(AddCategoryCommand command)
        {
            var category = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryId }, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
