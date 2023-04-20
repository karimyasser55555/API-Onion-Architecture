using Application.Contracts;
using Application.Features.Categories.Commands.CreateCategory;
using Domain;
using MediatR;
using QenaDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryMinimalDto>
    {
        private readonly ICategoryRepository CategoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        public async Task<CategoryMinimalDto?> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = await CategoryRepository.GetByIdAsync(request.Id);

            if (category != null)
            {
               await CategoryRepository.DeleteCategoryAsync(category.Id) ;
               
            }
            return null;
        }
    }
}
