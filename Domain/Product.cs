using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(200)]
        public string Name { get; set; }
        [MinLength(10), MaxLength(500)]
        public string? Description { get; set; }
        public float Price { get; set; }
        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }
        public int Available { get; set; }

        private readonly IList<Image> images;
        public IEnumerable<Image> Images { get { return images; } }

        private readonly IList<Category> categories;
        public IEnumerable<Category> Categories { get { return categories; } }


        public Product(string name, float price, Category category, string? description = null, int? discountPercentage = null)
        {
            Name = name;
            Description = description;
            Price = price;
            DiscountPercentage = discountPercentage;
            images = new List<Image>();
            categories = new List<Category>()
            {
             category
            };
        }
        public Product() : this(null!, 0, null!)
        {

        }
        public bool AddCategory(Category category)
        {
            var categoryItem = Categories.FirstOrDefault(a => a.Name == category.Name);
            if (categoryItem == null)
            {
                categories.Add(category);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddImage(Image image)
        {
            var ImageItem = Images.FirstOrDefault(a => a.URL == image.URL);
            if (ImageItem == null)
            {
                images.Add(image);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
