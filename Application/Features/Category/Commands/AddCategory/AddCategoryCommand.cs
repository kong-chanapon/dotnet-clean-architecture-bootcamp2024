using System;
using Application.Models;
using MediatR;

namespace Application.Features.Category.Commands;

public class AddCategoryCommand: IRequest<CategoryDto>
{
    public AddCategoryRequestDto Request {get; set;}

    public AddCategoryCommand(AddCategoryRequestDto Reqeust)
    {
        this.Request = Reqeust;
    }
}
