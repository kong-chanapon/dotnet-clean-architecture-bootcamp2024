using System;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Category.Commands;

public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public AddCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper) {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Domain.Entities.Category>(command.Request);
        var result = await _categoryRepository.AddCategoryAsync(category);
        var categoryDto = _mapper.Map<CategoryDto>(result);
        return categoryDto;
    }
}
