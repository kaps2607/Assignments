﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.ProductFeature.Command.AddProduct
{
    public record AddProductCommand(Product product) : IRequest<Product>
    {
    }
}
