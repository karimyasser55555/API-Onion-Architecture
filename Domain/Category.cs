using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(200)]
        public string Name { get; set; }
        
        public Category? ParentCategory { get; set; }

        private readonly IList<Category> subCategories;
        public IEnumerable<Category> SubCategories { get { return subCategories; } }

        public readonly IList<Product> products;
        public IEnumerable<Product> Products { get { return products; } }
        public Category(string name, Category? parentcategory = null)
        {
            Name = name;
            ParentCategory = parentcategory;
            subCategories = new List<Category>();
            products = new List<Product>();
        }
        public Category() : this(null!, null!)
        {

        }
        public bool AddSubCategory(Category subcategory)
        {
            var category = SubCategories.FirstOrDefault(a => a.Name == subcategory.Name);
            if (category == null)
            {
                subCategories.Add(subcategory);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddProduct(Product product)
        {
            var productItem = Products.FirstOrDefault(a => a.Name == product.Name);
            if (productItem == null)
            {
                products.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
