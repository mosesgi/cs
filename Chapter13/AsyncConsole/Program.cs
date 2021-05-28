using System;
using System.Net.Http;
using System.Threading.Tasks; 
using static System.Console;

namespace AsyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task.Run(new Action(fetchUrlData("http://www.apple.com")));
            Task t = Task.Run(() => FetchUrlData("http://www.apple.com"));
            Task.WaitAll(t);
        }

        // static async Task Main(string[] args)
        // {
        //     await FetchUrlData("http://www.baidu.com");
        // }

        static async Task FetchUrlData(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            WriteLine("{0} home page has {1:N0} bytes", url, response.Content.Headers.ContentLength);
        }
    }
}
