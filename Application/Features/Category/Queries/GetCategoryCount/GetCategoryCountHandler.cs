using System;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryCount;

public class GetCategoryCountHandler : IRequestHandler<GetCategoryCountQuery, int>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryCountHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<int> Handle(GetCategoryCountQuery request, CancellationToken cancellationToken)
    {
        var result = _categoryRepository.GetCategoryCountAsync();
        return result;
    }
}
