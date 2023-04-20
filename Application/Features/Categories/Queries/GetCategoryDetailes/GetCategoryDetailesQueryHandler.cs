using Application.Contracts;
using MediatR;
using QenaDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoryDetailes
{
    public class GetCategoryDetailesQueryHandler : IRequestHandler<GetCategoryDetailesQuery, CategoryDetailsDto?>
    {
        private readonly ICategoryRepository CategoryRepository;
        public GetCategoryDetailesQueryHandler(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public async Task<CategoryDetailsDto?> Handle(GetCategoryDetailesQuery request, CancellationToken cancellationToken)
        {
            var category = await CategoryRepository.GetByIdAsync(request.Id);

            if(category != null)
            {
                return new CategoryDetailsDto(category.Id, category.Name);
            }
            else
            {
                return null;
            }
            
        }
    }
}
