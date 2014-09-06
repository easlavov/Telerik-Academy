namespace ChatConsoleClient
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Linq;

    public class Chat
    {
        private MongoDatabase db;

        public Chat(MongoDatabase database)
        {
            this.db = database;
        }

        public void Start()
        {
            var messages = this.db.GetCollection<BsonDocument>("Messages");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    var newMessage = new BsonDocument
                    {
                        { "Author", username },
                        { "Text", input },
                        { "Time", DateTime.Now }
                    };

                    messages.Insert(newMessage);                    
                }
                    
                var formattedMessages = messages.FindAll()
                                                .Select(m => string.Format("[{0}] {1}: {2}", m["Time"]
                                                                   .ToLocalTime(), m["Author"], m["Text"]));

                string output = string.Join(Environment.NewLine, formattedMessages);
                Console.WriteLine(output);
            }
        }
    }
}
