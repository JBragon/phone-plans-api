using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace JBragon.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var directory = Directory.GetCurrentDirectory();
            CreateHostBuilder(args, directory).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, string directory) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                    /* Por já realizarmos o deploy no ECS da AWS, não é necessário a inclusão do provider de log da AWS
                     * pois os logs da console do container já são enviados automaticamente para o CloudWatch Logs.
                     * A menos que você queira customizar um grupo de logs diferente do container/realizar formatações especificas para o seu log*/
                    //logging.AddAWSProvider();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseContentRoot(directory);
                    webBuilder.UseWebRoot(Path.Combine(directory, "wwwroot"));
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();

                });
    }
}
