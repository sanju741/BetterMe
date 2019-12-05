using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //register mvc service
            //todo explore mvc's different contract
            services.AddMvc()
                .AddMvcOptions(x => x.OutputFormatters.Add(
                new XmlDataContractSerializerOutputFormatter()));
            //.AddJsonOptions(x => // changes json formatting.
            //                     // Here it changes the json naming convention from camel case to exact property name
            //{
            //    if (x.SerializerSettings.ContractResolver != null)
            //    {
            //        var castedResolver = x.SerializerSettings.ContractResolver as DefaultContractResolver;
            //        castedResolver.NamingStrategy=new CamelCaseNamingStrategy();
            //    }
            //});

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
                app.UseExceptionHandler();
            }

            //add status code middle ware
            app.UseStatusCodePages();

            //add mvc middleware after exception middleware
            app.UseMvc();


            //We are using attribute based routing so we don't need to configure convention based routing
            #region Configuring Cnvention Based Routing
            //1. using default route with mvc
            //app.UseMvcWithDefaultRoute();

            //2.
            //app.UseMvc(route =>
            //{
            //    route.MapRoute(
            //        name: "default",
            //        template: "{controller=cities}/{action=getcities}/{id?}");
            //});

            //3. using route config class
            //app.UseMvc(route=>RouteConfig.Use(route));

            #endregion Configuring Cnvention Based Routing
        }
    }

    //custom route config class
    public  static class RouteConfig{
        public static IRouteBuilder Use(IRouteBuilder route)
        {
           return route.MapRoute(name: "AppleRoute", template: "{controller=Cities}/{action=GetCities}/{id?}");
        }
    }
}
