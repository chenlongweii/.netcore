using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace myApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseUrls("http://local:8564", "http://local:8565")
                .UseKestrel()
                
                //.Configure(app => app.Run(async context => await context.Response.WriteAsync("Hello World")))
                .UseStartup<Startup>()
              .Build()
              .Run();
        }
    }
    public class HelloController : Controller
    {
        [HttpGet("/hello/{name}")]
        public IActionResult SayHello(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection svcs)
        {
            svcs.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
