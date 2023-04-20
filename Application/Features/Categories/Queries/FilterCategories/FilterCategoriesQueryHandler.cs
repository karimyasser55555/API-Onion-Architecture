using Application.Contracts;
using MediatR;
using QenaDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.FilterCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<FilterCategoriesQuery, IEnumerable<CategoryMinimalDto>>
    {
        private readonly ICategoryRepository CategoryRepository;
        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryMinimalDto>> Handle(FilterCategoriesQuery request, CancellationToken cancellationToken)
        {
            return (await CategoryRepository.FillterByAsync(request.Fillter ,request.ParentCategoryId))
                 .Select(a => new CategoryMinimalDto { Id = a.Id, Name = a.Name });
        }
    }
}
