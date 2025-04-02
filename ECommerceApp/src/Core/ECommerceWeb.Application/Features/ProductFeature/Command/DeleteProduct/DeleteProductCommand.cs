using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceWeb.Application.Features.ProductFeature.Command.DeleteProduct
{
    public record DeleteProductCommand(int id) : IRequest<bool>
    {
    }
}
