using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            var http = new HttpClient();
            const string baseAddress = "http://localhost:5000";
            const string path = "/api/values";
            http.BaseAddress = new Uri(baseAddress);

            for (int i = 0; i < 10; i++)
            {
                try {
                    HttpResponseMessage response = await http.GetAsync(path);
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"received '{content}' from '{baseAddress}{path}'");
                } catch (Exception exception) {
                    Console.WriteLine("Caught exception:");
                    Console.WriteLine(exception.StackTrace);
                }
            }
        }
    }
}
