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
                    //var port = Environment.GetEnvironmentVariable("PORT");

                    webBuilder.UseStartup<Startup>();
                    //.UseUrls("http://*:" + port);
                });
    }
}

//docker tag alquilarmvpapi registry.heroku.com/seminario1alquilar/web
//docker push registry.heroku.com/seminario1alquilar/web 
//heroku container:release web -a seminario1alquilar