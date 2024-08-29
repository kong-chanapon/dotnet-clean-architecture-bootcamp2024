using System;
using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Commands.UpdateBlogPost;

public class UpdateBlogPostCommand:IRequest<BlogPostDto>
{
    public UpdateBlogPostRequestDto Reqeust{get; set;}
    public Guid Id{get; set;}
    public UpdateBlogPostCommand(Guid id, UpdateBlogPostRequestDto reqeust)
    {
        Id = id;
        Reqeust = reqeust;
    }


}