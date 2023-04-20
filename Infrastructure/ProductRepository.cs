using Application.Contracts;
using Context;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        private readonly QenaDbContext QenaDbContext;

        public ProductRepository(QenaDbContext qenaDbContext) :base(qenaDbContext)
        {
            QenaDbContext = qenaDbContext;
        }
        public Task<IEnumerable<Product>> FillterBy(string? filter = null, int? fromPrice = null, int? toPrice = null, bool? isAvailable = null, bool? hasDiscount = null, int? categoryId = null)
        {
            filter = filter.ToLower();
            IEnumerable<Product> products = QenaDbContext.Products
             .Where(a => filter == null || a.Name.ToLower().Contains(filter) || a.Description.ToLower().Contains(filter))
             .Where(a => fromPrice == null || a.Price >= fromPrice)
             .Where(a => toPrice == null || a.Price >= toPrice)
             .Where(a => isAvailable == null || a.Available > 0)
             .Where(a => hasDiscount == null || a.DiscountPercentage != null)
             .Where(a => categoryId == null || a.Categories.Any(b => b.Id == categoryId));

            return Task.FromResult(products);
                
        }
    }
}
