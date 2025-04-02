using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderFeature.Query.GetOrderByIdQuery
{
    public record GetOrderByIdQuery(int id) : IRequest<Orders>;
}
