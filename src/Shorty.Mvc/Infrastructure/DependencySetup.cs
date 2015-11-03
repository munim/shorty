using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using Autofac.Integration.Mvc;
using Shorty.Core;
using Shorty.Core.Data;
using Shorty.Data;

namespace Shorty.Mvc.Infrastructure
{
    public class DependencySetup
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof (MvcApplication).Assembly)
                .PropertiesAutowired()
                .InstancePerRequest();

            builder.RegisterType(typeof(AppDbContext))
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterModule(new AutofacServiceModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}