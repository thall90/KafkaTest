using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.BackgroundServices;
using Api.KafkaWrappers;
using Api.KafkaWrappers.Interfaces;
using Api.Utilities;
using Api.Utilities.Interfaces;
using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Api
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kafka Order Handler API", Version = "v1" });
            });

            // services.Configure<ProducerConfig>(Configuration.GetSection("producer"));
            // services.Configure<ConsumerConfig>(Configuration.GetSection("consumer"));

            var producerConfig = new ProducerConfig();
            var consumerConfig = new ConsumerConfig();
            Configuration.Bind("producer",producerConfig);
            Configuration.Bind("consumer",consumerConfig);

            services.AddSingleton(producerConfig);
            services.AddSingleton(consumerConfig);

            services.AddTransient<IJsonDataSerializer, JsonDataSerializer>();
            services.AddTransient<IProducerWrapper, ProducerWrapper>();
            services.AddTransient<IConsumerWrapper, ConsumerWrapper>();

            services.AddHostedService<OrderProcessorService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kafka OrderHandler V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
