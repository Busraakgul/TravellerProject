//using BusinessLayer.Abstract;
//using BusinessLayer.Concrete;
//using BusinessLayer.Container;
//using BusinessLayer.ValidationRules;
//using DataAccessLayer.Abstract;
//using DataAccessLayer.Concrete;
//using DataAccessLayer.EntityFramework;
//using DTOLayer.DTOs.AnnouncementDTOs;
//using EntityLayer.Concrete;
//using FluentValidation;
//using FluentValidation.AspNetCore;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.AspNetCore.Mvc.Razor;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using TravellerProject.Models;
////using TravellerCoreProject.CQRS.Handlers.DestinationHandlers;

//namespace TravellerCoreProject
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {


//            //services.AddMediatR(typeof(Startup).Assembly);


//            //services.AddScoped<GetAllDestinationQueryHandler>();
//            //services.AddScoped<GetDestinationByIDQueryHandler>();
//            //services.AddScoped<CreateDestinationCommandHandler>();
//            //services.AddScoped<RemoveDestinationCommandHandler>();
//            //services.AddScoped<UpdateDestinationCommandHandler>();

//            services.AddLogging(x =>
//            {
//                x.ClearProviders();
//                x.SetMinimumLevel(LogLevel.Debug);
//                x.AddDebug();

//            });
//            services.AddDbContext<Context>();
//            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

//            services.AddMvc(config =>
//            {
//                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//                config.Filters.Add(new AuthorizeFilter(policy));
//            });

//            services.AddMvc();

//            services.AddLocalization(opt =>
//            {
//                opt.ResourcesPath = "Resources";
//            });

//            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

//            services.ConfigureApplicationCookie(opt =>
//            {
//                opt.LoginPath = "/Login/SignIn";
//            });

//            services.AddHttpClient();

//            services.ContainerDependencies();

//            services.AddAutoMapper(typeof(Startup));

//            services.CustomValidator();




//            services.AddControllersWithViews().AddFluentValidation();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
//        {
//            var path = Directory.GetCurrentDirectory();
//            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseAuthentication();

//            app.UseRouting();

//            app.UseAuthorization();

//            var suppertedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
//            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppertedCultures[1]).AddSupportedCultures(suppertedCultures).AddSupportedUICultures(suppertedCultures);
//            app.UseRequestLocalization(localizationOptions);


//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Login}/{action=SignIn}/{id?}");
//            });
//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                  name: "areas",
//                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//                );
//            });


//        }
//    }
//}