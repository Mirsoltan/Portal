﻿using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
//using Data.Contracts;
//using Data.Repositories;
//using Data.UnitOfWork;
//using Services;
//using Services.Api;
//using Services.Api.Contract;
//using Services.Contracts;

namespace IocConfig
{
    public static class AddCustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            //services.AddScoped<IEmailSender, EmailSender>();
            //services.AddTransient<IjwtService, jwtService>();
            return services;
        }
    }
}