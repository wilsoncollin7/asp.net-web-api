﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApi.Models
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
