using System;
using Application.Contracts.Persistence;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.AddBlogPost;

public class AddBlogPostHandler : IRequestHandler<AddBlogPostCommand, BlogPostDto>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public AddBlogPostHandler(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<BlogPostDto> Handle(AddBlogPostCommand command, CancellationToken cancellationToken)
    {
        var blogPost = _mapper.Map<Domain.Entities.BlogPost>(command.Request);

        foreach(var categoryId in command.Request.Categories){
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if(category is not null){
                blogPost.Categories.Add(category);
            }
        }

        var result = await _blogPostRepository.AddBlogPostAsync(blogPost);

        return _mapper.Map<BlogPostDto>(result);
    }
}
