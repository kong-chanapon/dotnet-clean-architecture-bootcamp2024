using System;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var updateCategory = _mapper.Map<Domain.Entities.Category>(command.Request);
        updateCategory.Id = command.Id;
        var reuslt = await _categoryRepository.UpdateCategoryAsync(updateCategory);
    
        return _mapper.Map<CategoryDto>(reuslt);
    }
}
