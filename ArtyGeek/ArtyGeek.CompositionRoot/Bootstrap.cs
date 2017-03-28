using ArtyGeek.Common.Context.Abstraction;
using ArtyGeek.Common.Context.Implementation;
using ArtyGeek.Common.Mapping;
using ArtyGeek.DataAccess.Contexts;
using ArtyGeek.DataAccess.Repositories;
using ArtyGeek.DataModel.Repositories;
using ArtyGeek.Operations.Abstraction;
using ArtyGeek.Operations.Implementation;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtyGeek.Api.CompositionRoot
{
    public class Bootstrap
    {
        public static void Configure(ServiceContainer container)
        {
            // Common
            container.Register<ICryptographyContext, CryptographyContext>(new PerRequestLifeTime());
            container.Register<IPasswordContext, PasswordContext>(new PerRequestLifeTime());
            container.Register<IObjectMapper, EmitObjectMapper>(new PerContainerLifetime());

            // Data access
            container.Register<ArtyGeekContext, ArtyGeekContext>();
            container.Register<IUserRepository, UserRepository>(new PerRequestLifeTime());

            // Operations
            container.Register<IAuthenticationOperations, AuthenticationOperations>(new PerRequestLifeTime());
        }
    }
}