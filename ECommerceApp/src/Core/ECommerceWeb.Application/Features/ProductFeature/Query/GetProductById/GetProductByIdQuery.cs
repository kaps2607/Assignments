using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.ProductFeature.Query.GetProductById
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;
}
