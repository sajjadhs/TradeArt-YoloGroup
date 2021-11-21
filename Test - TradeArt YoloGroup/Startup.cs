using GraphQLDataClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Test___TradeArt_YoloGroup.Services.Common;
using Test___TradeArt_YoloGroup.Utilities;

namespace Test___TradeArt_YoloGroup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddGQLDataClient(q=>q.EndPointUrl= "https://api.blocktap.io/graphql");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TradeArt_YoloGroup", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            registerServices(services);
        }

        #region  Service REG 
        private void registerServices(IServiceCollection services)
        {
            services.AddSingleton<HashCalculator>();
            services.Scan(scan =>
            scan.FromAssembliesOf(typeof(IDependencyTagged))
            .AddClasses(q => q.AssignableTo(typeof(IDependencyTagged)))
            .AsMatchingInterface()
            .WithScopedLifetime());
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                

            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeArt_YoloGroup v1"));

            app.UseHttpsRedirection();
            app.UseMiddleware<Middlewares.ResponseTimeMiddleware>();
            app.UseSerilogRequestLogging();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
