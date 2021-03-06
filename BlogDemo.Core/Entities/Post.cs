﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Core.Entities
{
    public class Post: EntityBase
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Body{ get; set; }
        public DateTime LastModified { get; set; }
        public string Remark { get; set; }
    }
}
