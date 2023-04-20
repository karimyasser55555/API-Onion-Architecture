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
    public class CategoryRepository :Repository<Category,int>, ICategoryRepository
    {
        public QenaDbContext QenaDbContext { get; }
        public CategoryRepository(QenaDbContext qenaDbContext): base (qenaDbContext)
        {
            QenaDbContext = qenaDbContext;
        }

        public async Task<IEnumerable<Category>> FillterByAsync(string? filter = null, int? ParentCateforyId = null)
        {
            IEnumerable<Category> categories = QenaDbContext.Categories
            .Where(a => filter == null || a.Name.ToLower().Contains(filter.ToLower()))
            .Where(a => ParentCateforyId != null|| a.ParentCategory != null && a.ParentCategory.Id == ParentCateforyId); 
            return await Task.FromResult(categories);
        }
    }
}
