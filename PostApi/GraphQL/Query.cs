using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostApi.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using PostApi.GraphQL.Data;
using Microsoft.AspNetCore.Mvc;

namespace PostApi.GraphQL
{
    public class Query
    {
        private readonly PostsRepository _PRepository;

        public Query(PostsRepository PRepository)
        {
            _PRepository = PRepository;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _PRepository.Get_Posts();
        }

        public Post GetPost(int id)
        {
            return _PRepository.Get_Post(id);
        }

        public string GetTest()
        {
            return _PRepository.Get_Test();
        }
    }
}
