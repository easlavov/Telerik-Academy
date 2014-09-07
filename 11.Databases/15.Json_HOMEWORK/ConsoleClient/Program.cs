namespace ConsoleClient
{
    using System;
    using System.Net;
    using System.Xml;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class Program
    {
        static void Main()
        {
            string feedUrl = "http://forums.academy.telerik.com/feed/qa.rss";
            var webClient = new WebClient();
            string fileName = "feed.rss";

            // 2. Download the feed content
            webClient.DownloadFile(feedUrl, fileName);
            var xml = new XmlDocument();
            xml.Load(fileName);

            // 3. Parse the XML from the feed to JSON
            var json = JsonConvert.SerializeXmlNode(xml, Newtonsoft.Json.Formatting.Indented);

            // 4. Using LINQ-to-JSON select all the question titles and print them to the console
            var parsed = JObject.Parse(json);
            var titles = parsed["rss"]["channel"]["item"].Select(t => (string)t["title"]).ToArray();
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine();
            Console.WriteLine("Press a key to display POCO");
            Console.ReadKey();

            // 5. Parse the JSON string to POCO
            var poco = JsonConvert.DeserializeObject<object>(json);
            Console.WriteLine(poco);
        }
    }
}
