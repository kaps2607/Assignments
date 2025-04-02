using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain;
using MediatR;

namespace ECommerceWeb.Application.Features.CategoryFeature.Query.GetAllCategories
{
    public record GetAllCategoriesQuery() : IRequest<IEnumerable<Category>>;
}
