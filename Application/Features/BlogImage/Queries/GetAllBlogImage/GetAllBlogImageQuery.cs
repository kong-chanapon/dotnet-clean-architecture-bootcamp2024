using System;
using Application.Models.Image;
using MediatR;

namespace Application.Features.BlogImage.Queries.GetAllBlogImage;

public class GetAllBlogImageQuery:IRequest<List<BlogImageDto>>
{

}
