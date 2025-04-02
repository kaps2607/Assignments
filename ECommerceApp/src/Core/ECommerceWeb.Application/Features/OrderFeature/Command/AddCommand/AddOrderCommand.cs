using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderFeature.Command.AddCommand
{
    public record AddOrderCommand(string UserId, int quantity, int ProductId) : IRequest<Orders>;
}
