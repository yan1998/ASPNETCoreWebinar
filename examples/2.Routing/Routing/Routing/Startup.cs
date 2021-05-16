using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Routing
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // the main endpoint
                endpoints.MapGet("/", async context =>
                {
                    var response = "<a href='/hello/Yan'>/hello/{name:alpha}</a><br/>" +
                        "<a href='/hello/5' target='_blank'>/hello/{name:int}</a><br/>" +
                        "<a href='/ageCheck/25' target='_blank'>/ageCheck/{age:int:min(18)}</a><br/>" +
                        "<a href='/ageCheck/15' target='_blank'>/ageCheck/{age:int:range(1,17)}</a><br/>" +
                        "<a href='/Home/Get/5' target='_blank'>/{controller}/{action}/{id?}</a><br/>" +
                        "<a href='/Home/' target='_blank'>/Home/{action:alpha=Default}</a>";
                    await context.Response.WriteAsync(response);
                });

                // Datatype restriction
                endpoints.MapGet("/hello/{name:alpha}", async context =>
                {
                    var name = context.Request.RouteValues["name"];
                    await context.Response.WriteAsync($"Hello {name}!");
                });

                endpoints.MapGet("/hello/{id:int}", async context =>
                {
                    var id = int.Parse(context.Request.RouteValues["id"].ToString());
                    await context.Response.WriteAsync($"Hello! Your id is {id}!");
                });

                // You can use range(x,y), min(x), max(y), length(x), maxLenth(x), etc...
                endpoints.MapGet("/ageCheck/{age:int:min(18)}", async context =>
                {
                    await context.Response.WriteAsync($"Hello! Your age is Okay! Welcome!");
                });

                endpoints.MapGet("/ageCheck/{age:int:range(1,17)}", async context => 
                {
                    await context.Response.WriteAsync($"Hello! Your age is not Okay! You should go away!");
                });

                // You can specify optional parameter
                endpoints.MapGet("/{controller:alpha}/{action:alpha}/{id?}", async context =>
                {
                    var controller = context.Request.RouteValues["controller"];
                    var action = context.Request.RouteValues["action"];
                    var id = context.Request.RouteValues["id"];
                    await context.Response.WriteAsync($"Controller = {controller}, action = {action}, id = {id ?? "Not specified"}");
                });

                //You can specify default value
                endpoints.MapGet("/Home/{action:alpha=Default}", async context =>
                {
                    var action = context.Request.RouteValues["action"];
                    await context.Response.WriteAsync($"Action = {action}");
                });
            });
        }
    }
}
