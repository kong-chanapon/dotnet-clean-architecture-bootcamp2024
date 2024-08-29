using System;
using Application.Models;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryByUrlHandle;

public class GetCategoryByUrlHandleQuery:IRequest<CategoryDto>
{
    public string UrlHandle;

    public GetCategoryByUrlHandleQuery(string urlHandle)
    {
        UrlHandle = urlHandle;
    }
}
