using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlquilarMVP.API.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AlquilarMVP.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                        // builder =>
                        // {
                        //     builder.WithOrigins("https://localhost:3000", "http://localhost:3000",
                        //         "http://seminario-1-alquilar.herokuapp.com:80",
                        //         "https://seminario-1-alquilar.herokuapp.com:443",
                        //         "http://seminario1-front.herokuapp.com:80",
                        //         "https://seminario1-front.herokuapp.com:443")
                        //     .AllowAnyHeader()
                        //     .AllowAnyMethod();
                        // });

                        builder => {
                            builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        });
            });


            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing());

            //Config DB
            services.AddDbSettings(Configuration);

            //Custom extension with all the dependencies to inject. Using the default DI container provided by .net core
            services.AddBusiness();

            //Config Swagger
            services.AddOpenAPIGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });


            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
