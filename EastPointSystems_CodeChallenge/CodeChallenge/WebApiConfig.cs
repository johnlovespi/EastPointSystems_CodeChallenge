using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using CodeChallenge.Api.Controllers;
using CodeChallenge.Data.Interfaces;
using CodeChallenge.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CodeChallenge
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      var builder = new ContainerBuilder();

      builder.RegisterType<PingController>();
      builder.RegisterType<RegionsController>();
      builder.RegisterType<RegionRepository>()
        .As<IRegionRepository>()
        .SingleInstance();

      builder.RegisterApiControllers(typeof(RegionsController).Assembly);
      var container = builder.Build();
      config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional });

      config.Formatters.JsonFormatter.SupportedMediaTypes
        .Add(new MediaTypeHeaderValue("text/html"));
    }
  }
}
