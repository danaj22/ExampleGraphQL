using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleGraphQL.GraphQL.Types
{
    public class PatientGenderType : EnumerationGraphType<Data.Gender>
    {
        public PatientGenderType()
        {
            Name = "Gender";
            Description = "Płeć pacjenta";
        }
    }
}
