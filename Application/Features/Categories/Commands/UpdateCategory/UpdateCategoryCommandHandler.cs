using Application.Contracts;
using Application.Features.Categories.Commands.DeleteCategory;
using Domain;
using MediatR;
using QenaDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryMinimalDto>
    {
        private readonly ICategoryRepository CategoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        public async Task<CategoryMinimalDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? obj = await CategoryRepository.GetByIdAsync(request.Id);
            
            if ( obj != null)
            {
                obj.Name = request.Name;


                await CategoryRepository.UpdateAsync(obj);
                await CategoryRepository.SaveChangesAsync(); 


            }
             return null;
        }
    }
}
