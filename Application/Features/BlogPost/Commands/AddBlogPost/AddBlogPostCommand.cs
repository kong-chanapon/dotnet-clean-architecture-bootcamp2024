using System;
using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Commands.AddBlogPost;

public class AddBlogPostCommand:IRequest<BlogPostDto>
{
    public AddBlogPostRequestDto Request {get; set;}
    public AddBlogPostCommand(AddBlogPostRequestDto request)
    {
        Request = request;
    }    
}
