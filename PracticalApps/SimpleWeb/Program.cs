using Microsoft.AspNetCore.Hosting; // IWebHostBuilder.Configure
using Microsoft.AspNetCore.Builder; // IApplicationBuilder.Run
using Microsoft.AspNetCore.Http;    // HttpResponse.WriteAsync
using Microsoft.Extensions.Hosting; // Host

namespace SimpleWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure(app =>
                    {
                        app.Run(context =>
                            context.Response.WriteAsync("Hello World Wide Web!"));
                    });
                })
                .Build().Run();
        }
    }
}
