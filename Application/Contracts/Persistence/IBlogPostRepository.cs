using System;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IBlogPostRepository
{
        Task<BlogPost> GetByIdAsync(Guid id);
        Task<List<BlogPost>> GetAllAsync();
        Task<BlogPost> GetByUrlHandleAsync(string urlHandle);
        Task<BlogPost> AddBlogPostAsync(BlogPost BlogPost);
        Task<BlogPost> UpdateBlogPostAsync(BlogPost updateBlogPost);
        Task<BlogPost> DeleteBlogPostAsync(Guid id);
        Task<int> GetBlogPostCountAsync();
}
