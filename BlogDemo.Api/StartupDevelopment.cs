using AutoMapper;
using BlogDemo.Api.Extensions;
using BlogDemo.Core.Interfaces;
using BlogDemo.Infrastructure.Database;
using BlogDemo.Infrastructure.Repositories;
using BlogDemo.Infrastructure.Resource;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlogDemo.Api
{
    public class StartupDevelopment
    {
        private static IConfiguration Configuration { get; set; }

        public StartupDevelopment(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) // 服务注册
        {
            services.AddMvc();

            services.AddDbContext<BlogContext>(options =>
            {
                //var conn = Configuration["ConnectionStrings:DefaultConnection"];
                var conn = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlite(conn);
            });

            services.AddHttpsRedirection(opt =>
            {
                opt.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                opt.HttpsPort = 5001;
            });

            //services.AddHsts(opt =>
            //{
            //    opt.Preload = true;
            //    opt.IncludeSubDomains = true;
            //    opt.MaxAge = TimeSpan.FromDays(60);
            //    opt.ExcludedHosts.Add("example.com");
            //    opt.ExcludedHosts.Add("www.example.com");

            //});

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper();
            services.AddTransient<IValidator<PostResource>, PostResourceValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,ILoggerFactory loggerFactory) // 中间件
        {
            //app.UseHsts();
            app.UseBlogExceptionHandler(loggerFactory);

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
