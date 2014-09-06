namespace ChatConsoleClient
{
    using MongoDB.Driver;

    class Program
    {
        static void Main(string[] args)
        {
            string connection = "mongodb://telerik:chat@ds035300.mongolab.com:35300/mongochat";
            var db = GetMongoDatabase(connection);
            
            var chat = new Chat(db);
            chat.Start();
        }

        private static MongoDatabase GetMongoDatabase (string connection)
        {
            var client = new MongoClient(connection);
            var server = client.GetServer();
            var db = server.GetDatabase("mongochat");

            return db;
        }
    }
}
