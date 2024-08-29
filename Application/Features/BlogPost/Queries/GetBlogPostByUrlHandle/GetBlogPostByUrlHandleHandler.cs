using System;
using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPostByUrlHandle;

public class GetBlogPostByUrlHandleHandler : IRequestHandler<GetBlogPostByUrlHandleQuery, BlogPostDto>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public GetBlogPostByUrlHandleHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<BlogPostDto> Handle(GetBlogPostByUrlHandleQuery request, CancellationToken cancellationToken)
    {
        var blogPost = await _blogPostRepository.GetByUrlHandleAsync(request.UrlHandle);
        return _mapper.Map<BlogPostDto>(blogPost);
    }
}
