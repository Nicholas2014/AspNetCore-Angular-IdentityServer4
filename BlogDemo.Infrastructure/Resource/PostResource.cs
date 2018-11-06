using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Infrastructure.Resource
{
    public class PostResource
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Remark { get; set; }
    }
}
