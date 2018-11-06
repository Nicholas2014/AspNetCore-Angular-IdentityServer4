using System;
using BlogDemo.Core.Interfaces;
using BlogDemo.Infrastructure.Database;
using BlogDemo.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogDemo.Api
{
    public class StartupDevelopment
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) // 服务注册
        {
            services.AddMvc();

            services.AddDbContext<BlogContext>(options => { options.UseSqlite("Data Source=BlogDemo.db"); });

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app) // 中间件
        {
            //app.UseHsts();

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
