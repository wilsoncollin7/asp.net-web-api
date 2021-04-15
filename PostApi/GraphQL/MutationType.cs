using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using PostApi.GraphQL;
using PostApi.GraphQL.Types;
using PostApi.Models;

namespace PostApi.GraphQL
{
    public class MutationType: ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(t => t.AddPost(default))
                .Argument("post", a => a.Type<NonNullType<PostInputType>>());
        }
    }
}
