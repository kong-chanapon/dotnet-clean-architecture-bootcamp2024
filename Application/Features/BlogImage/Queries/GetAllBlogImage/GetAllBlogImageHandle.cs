using System;
using Application.Contracts;
using Application.Models.Image;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogImage.Queries.GetAllBlogImage;

public class GetAllBlogImageHandle : IRequestHandler<GetAllBlogImageQuery, List<BlogImageDto>>
{
    private readonly IBlogImageRepository _blogImageRepository;
    private readonly IMapper _mapper;

    public GetAllBlogImageHandle(IBlogImageRepository blogImageRepository, IMapper mapper)
    {
        _blogImageRepository = blogImageRepository;
        _mapper = mapper;
    }

    public async Task<List<BlogImageDto>> Handle(GetAllBlogImageQuery request, CancellationToken cancellationToken)
    {
        var result = await _blogImageRepository.GetAllAsync();
        return _mapper.Map<List<BlogImageDto>>(result);
    }
}
