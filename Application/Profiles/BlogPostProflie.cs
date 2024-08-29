using System;
using Application.Models.BlogPost;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class BlogPostProflie : Profile
{
    public BlogPostProflie()
    {
        CreateMap<AddBlogPostRequestDto, BlogPost>()
            .ForMember(des => des.Categories, opt => opt.MapFrom(src => new List<Category>()));
        CreateMap<UpdateBlogPostRequestDto, BlogPost>()
            .ForMember(des => des.Categories, opt => opt.MapFrom(src => new List<Category>()));;
        CreateMap<BlogPost, BlogPostDto>();
    }
}
