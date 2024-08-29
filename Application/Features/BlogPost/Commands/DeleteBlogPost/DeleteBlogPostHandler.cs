using System;
using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.DeleteBlogPost;

public class DeleteBlogPostHandler : IRequestHandler<DeleteBlogPostCommand, BlogPostDto>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public DeleteBlogPostHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<BlogPostDto> Handle(DeleteBlogPostCommand command, CancellationToken cancellationToken)
    {
        var blogPost = await _blogPostRepository.DeleteBlogPostAsync(command.Id);
        return _mapper.Map<BlogPostDto>(blogPost);
    }
}
