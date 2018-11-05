using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogDemo.Infrastructure.Database
{
    public class BlogContextSeed
    {
        public async static Task SeedAsync(BlogContext context,ILoggerFactory loggerFactory,int retry=0)
        {
            var retryForAvailability = retry;
            try
            {
                // TODO: Only run this if real database
                // context.Database.Migrate();

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(new List<Post>()
                    {
                        new Post()
                        {
                            Title = "Post title 1",
                            Body = "Post body 1",
                            Author = "jack",
                            LastModified = DateTime.Now
                        },
                        new Post()
                        {
                            Title = "Post title 2",
                            Body = "Post body 2",
                            Author = "David",
                            LastModified = DateTime.Now
                        },
                        new Post()
                        {
                            Title = "Post title 3",
                            Body = "Post body 3",
                            Author = "Nichole",
                            LastModified = DateTime.Now
                        },
                        new Post()
                        {
                            Title = "Post title 4",
                            Body = "Post body 4",
                            Author = "Sara",
                            LastModified = DateTime.Now
                        }
                    });

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                if (retryForAvailability<10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<BlogContextSeed>();
                    logger.LogError(e.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}
