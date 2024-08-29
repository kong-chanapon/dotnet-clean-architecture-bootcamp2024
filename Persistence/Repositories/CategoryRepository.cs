using Application.Contracts.Persistence;
using Application.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.Repositories {
    public class CategoryRepository : ICategoryRepository {
        protected readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }    

        public async Task<Category> AddCategoryAsync(Category category)
        {   
             await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(Guid id)
        {
            var target = await _dbContext.Categories.FindAsync(id);

            if(target == null){
                return null;
            }

            _dbContext.Categories.Remove(target);
            await _dbContext.SaveChangesAsync();
            return target;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            //AsNoTracking ไม่ต้องติดตาม column นั้น
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id) {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> GetByUrlHandleAsync(string urlHandle)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.UrlHandle == urlHandle);
        }

        public async Task<int> GetCategoryCountAsync()
        {
            return await _dbContext.Categories.CountAsync();
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var target = await _dbContext.Categories.FindAsync(category.Id);

            if(target == null){
                return null;
            }

            target.Name = category.Name;
            target.UrlHandle = category.UrlHandle;
            await _dbContext.SaveChangesAsync();
            return target;
        }
    }
}
