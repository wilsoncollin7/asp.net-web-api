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
                title = title,
                body = body
            };
            dbContext.posts.Add(post);
            dbContext.SaveChanges();
            return post;
        }
    }
}
