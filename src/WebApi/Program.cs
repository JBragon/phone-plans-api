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
                    /* Por j� realizarmos o deploy no ECS da AWS, n�o � necess�rio a inclus�o do provider de log da AWS
                     * pois os logs da console do container j� s�o enviados automaticamente para o CloudWatch Logs.
                     * A menos que voc� queira customizar um grupo de logs diferente do container/realizar formata��es especificas para o seu log*/
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
