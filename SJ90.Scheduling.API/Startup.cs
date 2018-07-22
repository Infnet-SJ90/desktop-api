using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace SJ90.Scheduling.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Gerenciador de agendamento",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core para lidar com configurações e gerencimento de agendamentos",
                        Contact = new Contact
                        {
                            Name = "SJ90",
                            Url = "https://github.com/Infnet-SJ90"
                        }
                    });

                    string applicationBasePath =
                        PlatformServices.Default.Application.ApplicationBasePath;
                    string applicationName =
                        PlatformServices.Default.Application.ApplicationName;
                    string xmlDocPath =
                        Path.Combine(applicationBasePath, $"{applicationName}.xml");

                    c.IncludeXmlComments(xmlDocPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Gerenciador de agendamentos");
            });
        }
    }
}
