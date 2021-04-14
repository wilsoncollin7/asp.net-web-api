using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace PostApi.GraphQL
{
    public class MutationType: ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor
                .Field(t => t.AddPost(default, default, default))
                .Argument("title", a => a.Type<NonNullType<StringType>>())
                .Argument("body", a => a.Type<NonNullType<StringType>>());
        }
    }
}
