using System;
using Application.Contracts.Persistence;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.GetAllCategories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>> {
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper) {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken) {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        var result = _mapper.Map<List<CategoryDto>>(categories);
        return result;
    }
}