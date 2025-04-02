using ECommerceWeb.Application.Features.OrderFeature.Command.AddCommand;
using ECommerceWeb.Application.Features.OrderFeature.Command.DeleteCommand;
using ECommerceWeb.Application.Features.OrderFeature.Command.UpdateCommand;
using ECommerceWeb.Application.Features.OrderFeature.Query.GetAllOrdersQuery;
using ECommerceWeb.Application.Features.OrderFeature.Query.GetOrderByIdQuery;
using ECommerceWeb.Domain;
using ECommerceWeb.Identity.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }


        [HttpPost]
        public async Task<ActionResult<Orders>> AddOrder([FromQuery] int productId, [FromBody] int quantity)
        {
            var userEmail = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user.Id == null)
            {
                return Unauthorized();
            }
            var addOrderCommand = new AddOrderCommand(user.Id, quantity, productId);
            var order = await _mediator.Send(addOrderCommand);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderCommand command)
        {
            if (id != command.order.OrderId)
            {
                return BadRequest("Order ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
