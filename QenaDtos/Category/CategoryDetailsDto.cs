using QenaDtos.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QenaDtos.Category
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(200)]
        public string Name { get; set; }
        public CategoryMinimalDto? ParentCategory { get; set; }
        public IEnumerable<CategoryMinimalDto>? SubCategories { get; set; }
        public IEnumerable<ProductMinimalDto>? Products { get; set; }
        public CategoryDetailsDto(int id, string name, CategoryMinimalDto? parentCategory = null, IEnumerable<CategoryMinimalDto>? subCategories = null, IEnumerable<ProductMinimalDto>? products = null)
        {
            Id = id;
            Name = name;
            ParentCategory = parentCategory;
            SubCategories = subCategories;
            Products = products;
        }
    }
}
