using PostApi.Models;
using HotChocolate;
using HotChocolate.Types;
using PostApi.GraphQL.Data;

namespace PostApi.GraphQL
{
    public class Mutation
    {
        private readonly PostsRepository _PRepository;

        public Mutation(PostsRepository PRepository)
        {
            _PRepository = PRepository;
        }
        public Post AddPost (Post post)
        {
            return _PRepository.Add_Post(post);
        }
    }
}
