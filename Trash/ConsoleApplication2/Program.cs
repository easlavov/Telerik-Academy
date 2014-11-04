using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongoClient = new MongoClient("mongodb://localhost");
            var server = mongoClient.GetServer();
            var database = server.GetDatabase("Students");

            var students = database.GetCollection<Student>("Students");
            students.Insert(new Student
            {
                Name = "Pesho",
                Age = 21,
                RegDate = DateTime.Now
            });


        }

        private class Student
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            public DateTime RegDate { get; set; }
        }
    }
}
