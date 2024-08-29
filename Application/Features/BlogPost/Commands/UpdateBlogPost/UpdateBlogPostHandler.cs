using System;
using Application.Contracts.Persistence;
using Application.Features.BlogPost.Commands.UpdateBlogPost;
using Application.Models.BlogPost;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.DeleteBlogPost;

public class UpdateBlogPostHandler : IRequestHandler<UpdateBlogPostCommand, BlogPostDto>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateBlogPostHandler(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<BlogPostDto> Handle(UpdateBlogPostCommand command, CancellationToken cancellationToken)
    {
        var updateBlogPost = _mapper.Map<Domain.Entities.BlogPost>(command.Reqeust);

        foreach(var categoryId in command.Reqeust.Categories){
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if(category is not null){
                updateBlogPost.Categories.Add(category);
            }
        }
        updateBlogPost.Id = command.Id;
        var result = await _blogPostRepository.UpdateBlogPostAsync(updateBlogPost);
        return _mapper.Map<BlogPostDto>(result);
    }
}
