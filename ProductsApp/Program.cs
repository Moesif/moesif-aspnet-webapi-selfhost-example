using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;
using System.Web.Http;
using Topshelf;
using Moesif.Middleware;
using ProductsApp.Settings;

namespace ProductsApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return (int)HostFactory.Run(x =>
            {
                x.Service<OwinService>(s =>
                {
                    s.ConstructUsing(() => new OwinService());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });
            });
        }
    }

    public class OwinService
    {
        private IDisposable _webApp;

        public void Start()
        {
            _webApp = WebApp.Start<StartOwin>("http://localhost:9000");
        }

        public void Stop()
        {
            _webApp.Dispose();
        }
    }

    public class StartOwin
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Use<MoesifMiddleware>(MoesifOptions.moesifOptions);

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            appBuilder.UseWebApi(config);
        }
    }

    public class HelloWorldController : ApiController
    {
        public string Get()
        {
            return "Hello, World!";
        }
    }
}
