
using ExampleGraphQL.GraphQL.Types;
using ExampleGraphQL.Repositories;
using GraphQL.Types;

namespace ExampleGraphQL.GraphQL
{

    public class GraphQLQuery : ObjectGraphType<object>
    {
        public GraphQLQuery(PatientRepository patientRepository)
        {
            Field<ListGraphType<PatientType>>(
                "patients",
                resolve: context => patientRepository.GetAll()
            );
        }
    }
}
