using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.OrderFeature.Command.UpdateCommand
{
    public record UpdateOrderCommand(Orders order) : IRequest<Orders>;
}
