using Application.Contracts;
using Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        private readonly QenaDbContext QenaDbContext;
        private readonly DbSet<TEntity> DbSet;
        public Repository(QenaDbContext qenaDbContext)
        {
            QenaDbContext = qenaDbContext;
            DbSet = qenaDbContext.Set<TEntity>(); 
        }
        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await DbSet.FindAsync(id);
        } 

        public async Task<TEntity> CreateAsync(TEntity item)
        {
            return (await DbSet.AddAsync(item)).Entity;
        }
        public async Task<TEntity> CreateOnDbAsync(TEntity item)
        {
            var data = await CreateAsync(item);
            await SaveChangesAsync();
            return data;
        }

        public async Task<bool> DeleteCategoryAsync(TId id)
        {
            var item = await GetByIdAsync(id);
            if(item != null)
            {
                DbSet.Remove(item);
                await SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        

        public async Task<bool> UpdateAsync(TEntity item)
        {
          var entity = DbSet.Update(item);
            
          if(entity != null)
            {
                return await Task.FromResult(true);   
            }
            else
            {
                return await Task.FromResult(false);
            }

        }

        public async Task<int> SaveChangesAsync()
        {
            return await QenaDbContext.SaveChangesAsync();
        }
    }
}
