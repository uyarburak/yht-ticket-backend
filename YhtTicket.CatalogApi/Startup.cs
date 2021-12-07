using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Net.Http.Headers;
using YhtTicket.Common.EybisClient;
using YhtTicket.Common.Infrastructure.Exceptions;
using YhtTicket.Common.Infrastructure.Extensions;
using YhtTicket.Common.Redis.Extensions;

namespace YhtTicket.CatalogApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YhtTicket.CatalogApi", Version = "v1" });
            });

            services.AddApplicationLayer();
            services.AddSingleton<ITcddService, TcddService>();
            services.AddHttpClient("yht", yhtClient =>
            {
                yhtClient.BaseAddress = new Uri("https://ebilet.tcddtasimacilik.gov.tr/WebServisWeb/rest/EybisRestApplication/");
                yhtClient.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                yhtClient.DefaultRequestHeaders.Add("User-Agent", "Dalvik/2.1.0 (Linux; U; Android 7.0; LG-H960 Build/NRD90U)");
                yhtClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "mobilProd14:8Jh6g81dP4p72k");
            });
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddRedis(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YhtTicket.CatalogApi v1"));
            }

            app.UseHttpsRedirection();

            // Global error handler
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
