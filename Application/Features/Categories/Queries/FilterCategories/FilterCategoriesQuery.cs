using MediatR;
using QenaDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.FilterCategories
{
    public class FilterCategoriesQuery : IRequest<IEnumerable<CategoryMinimalDto>>
    {
        public string? Fillter { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
