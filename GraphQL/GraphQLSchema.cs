using GraphQL.Types;
using GraphQL;
using System;
using GraphQL.Utilities;

namespace ExampleGraphQL.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<GraphQLQuery>();
        }
    }
}
