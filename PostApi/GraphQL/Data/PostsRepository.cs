using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostApi.Models;
using PostApi.GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PostApi.GraphQL.Data
{
    public class PostsRepository
    {
        private readonly IHttpContextAccessor _Http;

        private readonly PostContext _context;

        public PostsRepository(IHttpContextAccessor http, PostContext context)
        {
            _Http = http;
            _context = context;
        }

        public IEnumerable<Post> Get_Posts()
        {
            return _context.PostItems.AsEnumerable();
        }

        public Post Get_Post(int id)
        {
            var post =  _context.PostItems.Find(id);

            return post;
        }

        public string Get_Test()
        {
            return "test";
        }
    }
}
