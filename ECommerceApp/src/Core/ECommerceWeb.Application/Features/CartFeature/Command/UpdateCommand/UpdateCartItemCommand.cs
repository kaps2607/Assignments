﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.CartFeature.Command.UpdateCommand
{
    public record UpdateCartItemCommand(int CartItemId, int Quantity) : IRequest<CartItem>;
}
