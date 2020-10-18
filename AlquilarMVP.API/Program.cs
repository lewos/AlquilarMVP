using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AlquilarMVP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //https://stackoverflow.com/questions/59434242/asp-net-core-gives-system-net-sockets-socketexception-error-on-heroku
                    //var port = Environment.GetEnvironmentVariable("PORT");
                    //if (port == null) { port = "80"; }
                    //Console.WriteLine($"-aca leo  - - - -e-sfadfsaf    port: {port}");

                    webBuilder.UseKestrel();
                    webBuilder.UseUrls("http://*" + Environment.GetEnvironmentVariable("PORT"));
                    webBuilder.UseStartup<Startup>();
                    //.UseUrls("http://*:" + port)
                    //.UseKestrel();
                });
    }
}

//docker tag alquilarmvpapi registry.heroku.com/seminario1alquilar/web
//docker push registry.heroku.com/seminario1alquilar/web 
//heroku container:release web -a seminario1alquilar


//heroku container:push web --app seminario1alquilar & heroku container:release web --app seminario1alquilar
