using Data.HIS.Repositories;
using Data.Repositories;
using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Services.Api;
using Services.Api.Contract;
using Services.Contracts;
using Services.CustomeServices;
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
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<IjwtService, jwtService>();

            services.AddTransient<LocationRepository>();
            services.AddTransient<AdmissionReposotories>();


            return services;
        }
    }
}
