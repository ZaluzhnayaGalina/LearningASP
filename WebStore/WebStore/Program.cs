using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WebStore.DAL.Context;
using WebStore.Data;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<WebStoreContext>();
                   // db.Initialize();
                }
                catch(Exception e)
                {
                    services.GetRequiredService<ILogger>().LogError(e, "Ошибка инициализации контекста в Program.Main");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
