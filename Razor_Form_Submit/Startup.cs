using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Razor_Form_Submit
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
            string apiKey = Environment.GetEnvironmentVariable("WeatherAPIKey");
            if (apiKey == null)
            {
                apiKey = Environment.GetEnvironmentVariable("WeatherAPIKey", EnvironmentVariableTarget.User);
                if (apiKey == null)
                {
                    apiKey = Environment.GetEnvironmentVariable("WeatherAPIKey", EnvironmentVariableTarget.Machine);
                    if (apiKey == null)
                    {
                        Console.WriteLine("No API key found, supplying default");
                        Environment.SetEnvironmentVariable("WeatherAPIKey", "22efbafae330449988950549221307");
                    } 
                    else
                    {
                        Environment.SetEnvironmentVariable("WeatherAPIKey", apiKey);
                    }
                }
                else
                {
                    Environment.SetEnvironmentVariable("WeatherAPIKey", apiKey);
                }
            }
        }
    }
}
