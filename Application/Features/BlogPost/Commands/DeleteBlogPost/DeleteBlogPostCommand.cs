using System;
using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Commands.DeleteBlogPost;

public class DeleteBlogPostCommand:IRequest<BlogPostDto>
{
    public Guid Id {get; set;}
    public DeleteBlogPostCommand(Guid id)
    {
        Id = id;
    }   
}
