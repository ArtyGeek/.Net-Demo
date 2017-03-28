using ArtyGeek.Api.CompositionRoot;
using ArtyGeek.Api.Controllers.Abstract;
using ArtyGeek.Api.OAuth;
using ArtyGeek.Operations.Abstraction;
using ArtyGeek.Operations.Contexts;
using LightInject;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using ArtyGeek.Api.Provider;

[assembly: OwinStartup(typeof(ArtyGeek.Api.Startup))]

namespace ArtyGeek.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureWebApi(config);
            ServiceContainer container = ConfigureDependencyResolver(config);

            ConfigureOAuth(app, container);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private static void ConfigureOAuth(IAppBuilder app, IServiceFactory container)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(7),
                Provider = new SimpleAuthorizationServerProvider(() => container.GetInstance<IAuthenticationOperations>()),
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private static void ConfigureWebApi(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static ServiceContainer ConfigureDependencyResolver(HttpConfiguration httpConfig)
        {
            var container = new ServiceContainer();

            // Other
            Bootstrap.Configure(container);

            // Api
            container.Register<ICurrentUserProvider, CurrentUserProvider>(new PerRequestLifeTime());

            container.RegisterApiControllers(typeof(ApiControllerBase).Assembly);
            container.EnableWebApi(httpConfig);
            return container;
        }
    }
}