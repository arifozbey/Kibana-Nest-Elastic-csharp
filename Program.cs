using System;
using Nest;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace ArifElastic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            #region Get Url Connection String

            Console.WriteLine("***Kibana Dashboard http://kibanadashboardip:5601 ");
            Console.WriteLine("***Provide Log Post host URL (ex: http://elasticip:9200/): ");
            //var host = Console.ReadLine();
           var host = "http://elasticip:9200/";
            host = host + (host.EndsWith("/", StringComparison.InvariantCulture) ? "" : "/");

            #endregion

            #region Create Index

            Console.WriteLine("***Elastic-Kibana sayfasında 'Stack Management' Uzerinde Görünecek index Adi, daha sonra dashboard tasarımı bu index üzerinden yapılacak ");
            Console.WriteLine("index adi yazin: ");
            var indexName = Console
                .ReadLine()
                .ToLower(); // Index name needs to be lowercase
            
            // Example using REST to create index
            Console.WriteLine($"Creating index {indexName}...");
            new HttpClient().PutAsync(host + indexName, new JsonContent(new { }));

            #endregion

            #region Setup Elasticsearch Client
            
            var es = new ElasticClient(
                new ConnectionSettings(new Uri(host))
                .DefaultIndex(indexName)
            );

            #endregion

            #region Add Documents - Add Data -  Any Model 
            //Demo Sample Data
            for (int i = 0; i < 99999; i++)
            {
                System.Threading.Thread.Sleep(1000);    
                IndexResponse contentResponse;

                Console.WriteLine("Adding document...");
                contentResponse = es.IndexDocument(             // Add a document to the index
                    new MyDocument()                            // using a MyDocument object as the document
                    {
                        Title = i+" This is a test document",
                        Notes = i + "Hello World!",
                        Aciklama="Deneme Aciklama",
                        Header="Başlık",
                        Kayitzamani=DateTime.Now
                    });
                Console.WriteLine(contentResponse);

                Console.WriteLine("Adding document...");
                contentResponse = es.IndexDocument(             // Add a document to the index
                    new MyDocument()                            // using a MyDocument object as the document
                    {
                        Title = i + "This is a test document",
                        Notes = i + "Hello Office!",
                        Aciklama = "Deneme Aciklama",
                        Header = "Başlık",
                        Kayitzamani = DateTime.Now
                    });
                Console.WriteLine(contentResponse);
            }
          

            #endregion

            #region Search in Index
            
            Console.Write("Provide search query: ");
            var contentQuery = Console.ReadLine();
            Console.WriteLine("Searching...");
            var results = es.Search<MyDocument>(                    // Searching for type MyDocument,
                    search => search.Query(                         // Create a query
                        query => query.Bool(                        // where a match
                            match => match.Must(                    // must have
                                mustHave => mustHave.QueryString(   // this string
                                    queryString => queryString.Query(contentQuery)
                                )
                            )
                        )
                    )
                )
                .Documents // There is metadata available but we want the documents found
                .ToList();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Found: {results.Count}");
            Console.WriteLine("==============================");

            foreach(var doc in results)
            {
                Console.WriteLine(doc);
            }

            Console.WriteLine(Environment.NewLine);

            #endregion

            #region Attention! Delete Index in Elastic DB

            //// Example using REST to delete index
            //Console.WriteLine($"Deleting index {indexName}...");
            //new HttpClient().DeleteAsync(host + indexName);

            #endregion

            //Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
