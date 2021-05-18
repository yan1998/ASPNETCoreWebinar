using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Middleware.Middlewares;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //First way to create own middleware
            //app.Use(async (context, next) =>
            //{
            //    var stopwatch = new Stopwatch();
            //    stopwatch.Start();
            //    var requestGuid = Guid.NewGuid().ToString();
            //    logger.LogInformation($"{DateTime.Now:s} - Request {requestGuid} - {context.Request.Method} - {context.Request.Path}");

            //    try
            //    {
            //        await next.Invoke();
            //        logger.LogInformation($"{DateTime.Now:s} - Reponse {requestGuid} - {context.Response.StatusCode}. Elapsed time: {stopwatch.Elapsed}");
            //    }
            //    catch (Exception ex)
            //    {
            //        logger.LogError($"{DateTime.Now:s} - Response {requestGuid} - {context.Response.StatusCode} - {ex.Message}");
            //        throw;
            //    }
            //});

            // Second way to create own middleware
            //app.UseMiddleware<RequestLoggingMiddleware>();

            // Third way to create own middleware
            app.UseRequestLogging();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/test/{id}", async context =>
                {
                    await Task.Delay(3000);
                    var id = context.Request.RouteValues["id"];
                    await context.Response.WriteAsync($"Request with id = {id} was processed!");
                });

                endpoints.MapGet("/testException", async context =>
                {
                    throw new Exception("Let's check an error log!");
                });
            });
        }
    }
}
