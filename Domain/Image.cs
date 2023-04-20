using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [Required]
        public string URL { get; set; }
        public Product Product { get; set; }
        public Image(string url, Product product)
        {
            URL = url;
            Product = product;
        }
        public Image() : this(null!, null!)
        {

        }
    }
}
