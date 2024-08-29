using System;
using Application.Models.BlogPost;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetAllBlogPost;

public class GetAllBlogPostQuery:IRequest<List<BlogPostDto>>
{

}
