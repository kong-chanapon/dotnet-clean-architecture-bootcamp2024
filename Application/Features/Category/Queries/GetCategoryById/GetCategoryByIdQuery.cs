using System;
using Application.Models;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories;

public class GetCategoryByIdQuery:IRequest<CategoryDto>
{
    public Guid Id;

    public GetCategoryByIdQuery(Guid id)
    {
        Id = id;
    }
}
