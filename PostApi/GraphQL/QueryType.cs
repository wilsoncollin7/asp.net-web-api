using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using PostApi.GraphQL;
using PostApi.Models;

namespace PostApi.GraphQL
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetTest());

            descriptor.Field(t => t.GetPosts());

            descriptor.Field(t => t.GetPost(default))
                .Argument("id", a => a.Type<NonNullType<IntType>>());
        }
    }
}
