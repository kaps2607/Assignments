﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Application.Exceptions;
using ECommerceWeb.Application.Interfaces;
using MediatR;

namespace ECommerceWeb.Application.Features.CategoryFeature.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var getCategory = await _categoryRepository.GetCategoryByIdAsync(request.id);
            if (getCategory is null)
            {
                throw new NotFoundException($"Category with Id::{request.id} not found");

            }
            return await _categoryRepository.DeleteCategoryAsync(getCategory.CategoryId);
        }
    }
}
