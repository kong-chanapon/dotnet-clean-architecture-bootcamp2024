using System;
using Domain.Entities;

namespace Application.Contracts;

public interface IBlogImageRepository
{
    Task<BlogImage> SaveImage(BlogImage blogImage);
    Task<List<BlogImage>> GetAllAsync();
}
