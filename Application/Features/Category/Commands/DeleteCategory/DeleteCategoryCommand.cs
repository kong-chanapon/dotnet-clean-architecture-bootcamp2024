using System;
using Application.Models;
using MediatR;

namespace Application.Features.Category.Commands;

public class DeleteCategoryCommand:IRequest<CategoryDto>
{
    public Guid Id {get; set;}
    public DeleteCategoryCommand(Guid id)
    {
        Id = id;
    }

}
