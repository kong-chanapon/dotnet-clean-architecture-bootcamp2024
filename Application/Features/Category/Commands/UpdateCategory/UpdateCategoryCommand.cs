using System;
using Application.Models;
using MediatR;

namespace Application.Features.Category.Commands;

public class UpdateCategoryCommand:IRequest<CategoryDto>
{
    public UpdateCategoryRequestDto Request {get; set;}
    public Guid Id {get; set;}

    public UpdateCategoryCommand(Guid Id, UpdateCategoryRequestDto Request)
    {
        this.Id = Id;
        this.Request = Request;
    }


    
}
