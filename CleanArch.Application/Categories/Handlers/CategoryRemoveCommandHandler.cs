using CleanArch.Application.Categories.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Categories.Handlers
{
    public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryRemoveCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentException(nameof(categoryRepository));
        }

        public async Task<Category> Handle(CategoryRemoveCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetCategoryByIdAsync(request.Id);

            if (category == null)
                throw new ApplicationException("Entity could not be found");

            Category result = await _categoryRepository.RemoveAsync(category);
            return result;
        }
    }
}
