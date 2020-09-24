using System;
using System.IO;
using AutoMapper;
using Coravel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Data;
using IocConfig;
using IocConfig.Api.Middlewares;
using IocConfig.Api.Swagger;
using ViewModels.DynamicAccess;
using ViewModels.Settings;
using ReflectionIT.Mvc.Paging;

namespace WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IServiceProvider Services { get; }
        private readonly SiteSettings SiteSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SiteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ////services.AddDbContext<PortalDbContext>(options =>
            ////    options.UseSqlServer(
            ////        Configuration.GetConnectionString("PortalConnectionString")));

            ////services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            ////    .AddEntityFrameworkStores<PortalDbContext>();

            ////services.AddTransient<IConvertDates, ConvertDates>();

            ////services.AddControllersWithViews();
            ////services.AddRazorPages();

            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

            services.AddDbContext<PortalDbContext>(
                options => options.UseSqlServer
                (Configuration.GetConnectionString("SqlServer")));

            services.AddCustomServices();



            services.AddCustomIdentityServices();

            services.AddAutoMapper(typeof(Startup));

            services.AddScheduler();
            services.AddApiVersioning();
            services.AddSwagger();
            services.AddCustomAuthentication(SiteSettings);
            services.ConfigureWritable<SiteSettings>(Configuration.GetSection("SiteSettings"));

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    ConstantPolicies.DynamicPermission,
                    policy => policy.Requirements.Add(new DynamicPermissionRequirement()));
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Home/Index";
                options.AccessDeniedPath = "/Admin/Manage/AccessDenied";
            });


            services.AddSession(option =>
                {
                    option.IdleTimeout = TimeSpan.FromMinutes(10);
                    option.Cookie.Name = "HisPortal";
                    option.Cookie.HttpOnly = true;
                }
            );

            services.AddPaging(options => {
                options.ViewName = "Bootstrap4";
                options.HtmlIndicatorDown = "<i class='fa fa-sort-amount-down'></i>";
                options.HtmlIndicatorUp = "<i class='fa fa-sort-amount-up'></i>";
            });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cachePeriod = env.IsDevelopment() ? "600" : "605800";
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                appBuilder.UseCustomExceptionHandler();
            });

            app.UseWhen(context => !context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                //if (env.IsDevelopment())
                    appBuilder.UseDeveloperExceptionPage();
                //else
                //    appBuilder.UseExceptionHandler("/Home/Error");
            });


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CacheFiles")),
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public,max-age={cachePeriod}");
                },
                RequestPath = "/CacheFiles",
            });


            app.UseStaticFiles();

            app.UseCustomIdentityServices();

            var provider = app.ApplicationServices;

            //provider.UseScheduler(scheduler =>
            //{
            //    //scheduler.Schedule<SendWeeklyMessage>().Cron("29 20 * * 5"); //UTC Time
            //});

            //app.Use(async (context, next) =>
            //{
            //    await next();
            //    if (context.Response.StatusCode == 404)
            //    {
            //        context.Request.Path = "/home/error404";
            //        await next();
            //    }
            //});

            app.UseSwaggerAndUI();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
