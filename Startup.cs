using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using escola.Models;
using escola;
using escola.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace escola
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
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DataContext, DataContext>();
            services.AddControllers();
            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
 {
     c.SwaggerDoc("v1", new OpenApiInfo
     {
         Version = "v1",
         Title = "Escola",
         Description = "A simple example ASP.NET Core Web API",
         TermsOfService = new Uri("https://example.com/terms"),
         Contact = new OpenApiContact
         {
             Name = "Leonardo",
             Email = string.Empty,
             Url = new Uri("https://github.com/LeonardoMaia10/webApiEscola"),
         },
         License = new OpenApiLicense
         {
             Name = "Use under LICX",
             Url = new Uri("https://example.com/license"),
         }
     });
 });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Escola");
            });
        }
    }
}
