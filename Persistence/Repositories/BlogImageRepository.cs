using System;
using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class BlogImageRepository:IBlogImageRepository
{
    protected readonly ApplicationDbContext _dbContext;

    public BlogImageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<BlogImage>> GetAllAsync()
    {
        return await _dbContext.BlogImages.AsNoTracking().ToListAsync();
    }

    public async Task<BlogImage> SaveImage(BlogImage blogImage)
    {
        await _dbContext.BlogImages.AddAsync(blogImage);
        await _dbContext.SaveChangesAsync();
        return blogImage;
    }

}
