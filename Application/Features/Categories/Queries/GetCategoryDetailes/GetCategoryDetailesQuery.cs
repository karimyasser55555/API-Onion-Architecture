using MediatR;
using QenaDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoryDetailes
{
    public class GetCategoryDetailesQuery:IRequest<CategoryDetailsDto?>
    {
        public int Id { get; set; }
    }
}
