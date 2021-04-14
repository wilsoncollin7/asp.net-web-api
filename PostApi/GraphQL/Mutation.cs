using PostApi.Models;
using HotChocolate;
using HotChocolate.Types;

namespace PostApi.GraphQL
{
    public class Mutation
    {
        public Post AddPost ([Service] PostContext dbContext, string title, string body)
        {
            var post = new Post
            {
                Title = title,
                Body = body
            };
            dbContext.PostItems.Add(post);
            dbContext.SaveChanges();
            return post;
        }
    }
}
