using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo.Infrastructure.Database
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
    }
}
