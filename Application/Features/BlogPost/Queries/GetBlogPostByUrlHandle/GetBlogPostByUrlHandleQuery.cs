using System;
using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPostByUrlHandle;

public class GetBlogPostByUrlHandleQuery:IRequest<BlogPostDto>
{
    public string UrlHandle {get; set;}
    public GetBlogPostByUrlHandleQuery(string urlHandle)
    {
        UrlHandle = urlHandle;
    }
}
