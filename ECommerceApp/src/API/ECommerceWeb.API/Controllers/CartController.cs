using ECommerceWeb.Application.Features.CartFeature.Command.AddCommand;
using ECommerceWeb.Application.Features.CartFeature.Command.DeleteCommand;
using ECommerceWeb.Application.Features.CartFeature.Command.UpdateCommand;
using ECommerceWeb.Application.Features.CartFeature.Query.GetCartItemByIdQueryHandler;
using ECommerceWeb.Application.Features.CartFeature.Query.GetCartItemsQuery;
using ECommerceWeb.Domain;
using ECommerceWeb.Identity.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.API.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        readonly IMediator _mediator;
        readonly UserManager<ApplicationUser> _userManager;

        public CartController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult<CartItem>> AddCartItem([FromQuery] int productId, [FromBody] int quantity)
        {
            var userEmail = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user.Id == null)
            {
                return Unauthorized();
            }

            var cartItemCommand = new AddCartItemCommand(user.Id, quantity, productId);
            var cartItem = await _mediator.Send(cartItemCommand);
            //return CreatedAtAction(nameof(GetCartItemById), new { cartItemId = cartItem.CartItemId }, cartItem);
            return Ok(cartItem);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(string userId)
        {
            var cartItems = await _mediator.Send(new GetCartItemsQuery(userId));
            return Ok(cartItems);
        }

        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem(int cartItemId, UpdateCartItemCommand command)
        {
            if (cartItemId != command.CartItemId)
            {
                return BadRequest("Cart item ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            var result = await _mediator.Send(new DeleteCartItemCommand(cartItemId));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpGet("item/{cartItemId}")]
        public async Task<ActionResult<CartItem>> GetCartItemById(int cartItemId)
        {
            var cartItem = await _mediator.Send(new GetCartItemByIdQuery(cartItemId));
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }
    }
}
