using System;
using Application.Models.Image;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class BlogImageProfile:Profile
{
    public BlogImageProfile()
    {
        CreateMap<BlogImage, BlogImageDto>();
    }
}
