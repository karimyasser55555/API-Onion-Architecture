using Application.Contracts;
using Domain;
using MediatR;
using QenaDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryMinimalDto>
    {
        private readonly ICategoryRepository CategoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        public async Task<CategoryMinimalDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? ParentCategory = null;
            if (request.ParentCategoryId != null)
            {
                ParentCategory = await CategoryRepository.GetByIdAsync(request.ParentCategoryId.Value);
            }
            var category = new Category(request.Name, ParentCategory);
            category = await CategoryRepository.CreateOnDbAsync(category);

            return new CategoryMinimalDto() { Id = category.Id, Name = category.Name };
        }
    }
    
  
}
