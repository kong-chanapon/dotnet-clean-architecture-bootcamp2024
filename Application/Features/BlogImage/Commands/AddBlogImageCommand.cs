using System;
using Application.Models.Image;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.BlogImage.Commands;
public class AddBlogImageCommand:IRequest<BlogImageDto>
{
    public IFormFile File { get; set; }
    public string FileName { get; set; }
    public string Title { get; set; }
}
