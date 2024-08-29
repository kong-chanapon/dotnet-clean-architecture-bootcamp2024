using System;
using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPostById;

public class GetBlogPostByIdHandle : IRequestHandler<GetBlogPostByIdQuery, BlogPostDto>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public GetBlogPostByIdHandle(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<BlogPostDto> Handle(GetBlogPostByIdQuery request, CancellationToken cancellationToken)
    {
        var blogPost = await _blogPostRepository.GetByIdAsync(request.Id);
        return _mapper.Map<BlogPostDto>(blogPost);
    }
}
