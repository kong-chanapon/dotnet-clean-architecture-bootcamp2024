using System;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryByUrlHandle;

public class GetCategoryByUrlHandleHandler : IRequestHandler<GetCategoryByUrlHandleQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByUrlHandleHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByUrlHandleQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByUrlHandleAsync(request.UrlHandle);
        return _mapper.Map<CategoryDto>(category);
    }
}
