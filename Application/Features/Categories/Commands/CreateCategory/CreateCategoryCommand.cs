using MediatR;
using QenaDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryMinimalDto>
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public CreateCategoryCommand(string name, int? parentCategoryId = null)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        
    }
}
