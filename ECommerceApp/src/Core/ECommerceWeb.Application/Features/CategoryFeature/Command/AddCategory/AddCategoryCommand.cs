using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.CategoryFeature.Command.AddCategory
{
    public record AddCategoryCommand(Category category) : IRequest<Category>
    {
    }
}
