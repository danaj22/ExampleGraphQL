using ExampleGraphQL.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleGraphQL.Repositories
{
    public class PatientRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        public PatientRepository()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            // Poniżej podaj nazwę utworzonej przez siebie w poprzednim kroku bazy danych
            _database = _client.GetDatabase("GraphQL");

        }

        public IEnumerable<Patient> GetAll()
        {
            return _database.GetCollection<Patient>("Products").Find(_ => true).ToEnumerable();
        }
    }
}
