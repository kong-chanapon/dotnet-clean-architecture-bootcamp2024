using System;
using Application.Contracts;
using Application.Models.Image;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Features.BlogImage.Commands;

public class AddBlogImageHandler : IRequestHandler<AddBlogImageCommand, BlogImageDto>
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IBlogImageRepository _blogImageRepository;
    private readonly IMapper _mapper;

    public AddBlogImageHandler(IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IBlogImageRepository blogImageRepository, IMapper mapper)
    {
        _hostingEnvironment = hostingEnvironment;
        _httpContextAccessor = httpContextAccessor;
        _blogImageRepository = blogImageRepository;
        _mapper = mapper;
    }

    public async Task<BlogImageDto> Handle(AddBlogImageCommand request, CancellationToken cancellationToken)
    {
            var file = request.File;
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            Directory.CreateDirectory(Path.Combine(_hostingEnvironment.ContentRootPath, "Images"));

            var localPath = Path.Combine(_hostingEnvironment.ContentRootPath, "Images", $"{request.FileName}{fileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            //Update to database
            var httpRequest = _httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{request.FileName}{fileExtension}";

            var blogImage = new Domain.Entities.BlogImage {
                FileName = request.FileName,
                Title = request.Title,
                FileExtension = fileExtension,
                Url = urlPath,
                DateCreated = DateTime.Now
            };

            var result = await _blogImageRepository.SaveImage(blogImage);


            return _mapper.Map<BlogImageDto>(result);
    }
}
