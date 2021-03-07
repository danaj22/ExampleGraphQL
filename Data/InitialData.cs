using ExampleGraphQL.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleGraphQL.Data
{
    public static class InitialData
    {
        private static IMongoClient _client;
        private static IMongoDatabase _database;
        public static void Initialize()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            // Poniżej podaj nazwę utworzonej przez siebie w poprzednim kroku bazy danych
            _database = _client.GetDatabase("GraphQL");
            var data = _database.GetCollection<Patient>("patients");
            var count = data.EstimatedDocumentCount();
            if(count > 0)
            {
                return;
            }
            data.InsertOne(new Patient
            {
                Id = 1,
                FirstName = "Barbara",
                LastName = "Żydek",
                Pesel = "64091361956",
                Price = 219.5m,
                NfzBranch = 4,
                Gender = Gender.Female,
                Stock = 12,
                PhotoFileName = "shutterstock_66842440.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            data.InsertOne(new Patient
            {
                Id = 2,
                FirstName = "Piotr",
                LastName = "Stary",
                Pesel = "50100861287",
                Price = 125.9m,
                NfzBranch = 3,
                Gender = Gender.Female,
                Stock = 56,
                PhotoFileName = "shutterstock_222721876.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            }) ;

            data.InsertOne(new Patient
            {
                Id = 3,
                FirstName = "Adam",
                LastName = "Małysz",
                Pesel = "74060834792",
                Price = 199.99m,
                NfzBranch = 5,
                Gender = Gender.Male,
                Stock = 66,
                PhotoFileName = "shutterstock_6170527.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            data.InsertOne(new Patient
            {
                Id = 4,
                FirstName = "Krzysztof",
                LastName = "Krawczyk",
                Pesel = "61111813549",
                Price = 299.5m,
                NfzBranch = 5,
                Gender = Gender.Male,
                Stock = 3,
                PhotoFileName = "shutterstock_48040747.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            }) ;

            data.InsertOne(new Patient
            {
                Id = 5,
                FirstName = "Janina",
                LastName = "Ochocka",
                Pesel = "56030919241",
                Price = 350m,
                NfzBranch = 5,
                Gender = Gender.Other,
                Stock = 8,
                PhotoFileName = "shutterstock_441989509.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            data.InsertOne(new Patient
            {
                Id = 6,
                FirstName = "Jan",
                LastName = "Nowak",
                Pesel = "62062729334",
                Price = 450m,
                NfzBranch = 2,
                Gender = Gender.Other,
                Stock = 1,
                PhotoFileName = "shutterstock_495259978.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

        }
    }
}
