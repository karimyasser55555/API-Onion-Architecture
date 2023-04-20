﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IRepository<TEntity,TId> where TEntity : class
    {
        
        Task<TEntity?> GetByIdAsync(TId id);

        Task<TEntity> CreateAsync(TEntity item);
        Task<TEntity> CreateOnDbAsync(TEntity item);
        Task<bool> UpdateAsync(TEntity item);
        Task<bool> DeleteCategoryAsync(TId id);
        Task<int> SaveChangesAsync();
    }
}
