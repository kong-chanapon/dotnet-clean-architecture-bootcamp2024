using System;
using Application.Features.Category.Commands;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Contracts.Persistence;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.DeleteCategoryAsync(command.Id);
        return _mapper.Map<CategoryDto>(category);
    }
}
