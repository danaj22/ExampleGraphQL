using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleGraphQL.Data.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }
        [StringLength(10)]
        public string LastName { get; set; }
        public ProductType Type { get; set; }
        public string Pesel { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Column(TypeName = "decimal(2,0)")]
        public int NfzBranch { get; set; }
        public DateTimeOffset IntroducedAt { get; set; }

        [StringLength(100)]
        public string PhotoFileName { get; set; }
    }
}
