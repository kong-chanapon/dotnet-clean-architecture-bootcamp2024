using System;
using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPostById;

public class GetBlogPostByIdQuery:IRequest<BlogPostDto>
{
    public Guid Id;

    public GetBlogPostByIdQuery(Guid id)
    {
        Id = id;
    }
}
