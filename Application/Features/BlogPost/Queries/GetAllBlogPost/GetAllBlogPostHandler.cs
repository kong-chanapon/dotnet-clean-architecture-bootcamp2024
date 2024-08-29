using System;
using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetAllBlogPost;

public class GetAllBlogPostHandler : IRequestHandler<GetAllBlogPostQuery, List<BlogPostDto>>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public GetAllBlogPostHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<List<BlogPostDto>> Handle(GetAllBlogPostQuery request, CancellationToken cancellationToken)
    {
        var blogPosts = await _blogPostRepository.GetAllAsync();
        return _mapper.Map<List<BlogPostDto>>(blogPosts);
    }
}
