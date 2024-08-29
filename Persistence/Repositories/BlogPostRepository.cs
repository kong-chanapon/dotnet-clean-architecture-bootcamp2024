using System;
using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class BlogPostRepository : IBlogPostRepository
{
    protected readonly ApplicationDbContext _dbContext;

    public BlogPostRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BlogPost> AddBlogPostAsync(BlogPost blogPost)
    {
        await _dbContext.BlogPosts.AddAsync(blogPost);
        await _dbContext.SaveChangesAsync();
        return blogPost;
    }

    public async Task<BlogPost> DeleteBlogPostAsync(Guid id)
    {
        var target = await _dbContext.BlogPosts.Where(b => b.Id == id).Include(i => i.Categories).FirstAsync();

        if(target == null){
            return null;
        }

        _dbContext.BlogPosts.Remove(target);
        await _dbContext.SaveChangesAsync();
        return target;
    }

    public async Task<List<BlogPost>> GetAllAsync()
    {
        return await _dbContext.BlogPosts.AsNoTracking().Include(i => i.Categories).ToListAsync();
    }

    public async Task<int> GetBlogPostCountAsync()
    {
        return await _dbContext.BlogPosts.CountAsync();
    }

    public async Task<BlogPost> GetByIdAsync(Guid id)
    {
        return await _dbContext.BlogPosts.Where(b => b.Id == id).Include(i => i.Categories).FirstOrDefaultAsync();
    }

    public async Task<BlogPost> GetByUrlHandleAsync(string urlHandle)
    {
        return await _dbContext.BlogPosts.Where(b => b.UrlHandle == urlHandle).Include(i => i.Categories).FirstOrDefaultAsync();
    }

    public async Task<BlogPost> UpdateBlogPostAsync(BlogPost updateBlogPost)
    {
            var target = await _dbContext.BlogPosts.FindAsync(updateBlogPost.Id);

            if(target == null){
                return null;
            }

            target.Title = updateBlogPost.Title;
            target.ShortDescription = updateBlogPost.ShortDescription;
            target.Content = updateBlogPost.Content;
            target.FeaturedImageUrl = updateBlogPost.FeaturedImageUrl;
            target.UrlHandle = updateBlogPost.UrlHandle;
            target.Author = updateBlogPost.Author;
            target.IsVisible = updateBlogPost.IsVisible;
            target.Categories = updateBlogPost.Categories;
            await _dbContext.SaveChangesAsync();
            return target;
    }
}
