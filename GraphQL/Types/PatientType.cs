using ExampleGraphQL.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleGraphQL.GraphQL.Types
{
    public class PatientType : ObjectGraphType<Patient>
    {
        public PatientType()
        {
            Field(t => t.Id);
            Field(t => t.FirstName).Description("Imię pacjenta (max 10 znaków)");
            Field(t => t.LastName).Description("Nazwisko pacjenta (max 10 znaków)");
            Field(t => t.Pesel).Description("Pesel musi być!");
            Field(t => t.IntroducedAt).Description("When the product was first introduced in the catalog");
            Field(t => t.PhotoFileName).Description("The file name of the photo so the client can render it");
            Field(t => t.Price);
            Field(t => t.NfzBranch).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            Field<PatientGenderType>("Gender", "Płeć pacjenta.");
        }
    }
}
