﻿using Application.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application {
    public static class ApplicationServiceRegistration {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(cfg => cfg.AddProfileRegistration());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        public static IMapperConfigurationExpression AddProfileRegistration(this IMapperConfigurationExpression mapper) {
            mapper.AddProfile<CategoryProfile>();
            mapper.AddProfile<BlogPostProflie>();
            mapper.AddProfile<BlogImageProfile>();
            return mapper;
        }
    }
}
