using backend.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using backend.Code.Services;

namespace backend
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // -------------- Configuration ---------------

            services.Configure<OpenWeatherSecrets>(Configuration.GetSection("OpenWeatherAPI"));
            services.AddHttpClient<OpenWeatherService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //// --------- Vue historic mode configuration --------
            //app.Use(async (context, next) => {
            //    await next();

            //    var path = context.Request.Path.Value;

            //    if (context.Response.StatusCode == (int)HttpStatusCode.NotFound && !Path.HasExtension(path) && !path.StartsWith("/api", System.StringComparison.Ordinal)) {
            //        context.Request.Path = "/Home";
            //        context.Response.StatusCode = (int)HttpStatusCode.OK;
            //        await next();
            //    }
            //});
            //// --------

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
