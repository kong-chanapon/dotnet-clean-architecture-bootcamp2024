using System;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPostCount;

public class GetBlogPostCountHandler : IRequestHandler<GetBlogPostCountQuery, int>
{
    private readonly IBlogPostRepository _blogPostRepository;

    public GetBlogPostCountHandler(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }

    public Task<int> Handle(GetBlogPostCountQuery request, CancellationToken cancellationToken)
    {
        return _blogPostRepository.GetBlogPostCountAsync();
    }
}
