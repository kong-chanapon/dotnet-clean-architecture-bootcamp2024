using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence {
    public interface ICategoryRepository {
        Task<Category> GetByIdAsync(Guid id);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetByUrlHandleAsync(string urlHandle);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category updateCategory);
        Task<Category> DeleteCategoryAsync(Guid id);
        Task<int> GetCategoryCountAsync();
    }
}
