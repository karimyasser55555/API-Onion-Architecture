using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task<IEnumerable<Product>> FillterBy(string? filter = null, int? fromPrice = null, int? toPrice = null, bool? isAvailable = null, bool? hasDiscount = null, int? categoryId = null);
    }
}
