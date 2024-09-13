using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace AloraDesign
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            using IServiceScope scope = host.Services.CreateScope();
            IConfiguration config = scope.ServiceProvider.GetService<IConfiguration>();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
