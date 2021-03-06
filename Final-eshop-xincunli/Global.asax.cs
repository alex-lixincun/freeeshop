﻿using Final_eshop_entities.Migrations;
using Final_eshop_entities.Models;
using System.Data.Entity;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Final_eshop_xincunli
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
       new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));

            var config = System.Web.Http.GlobalConfiguration.Configuration;
            config.Formatters.Insert(0, new System.Net.Http.Formatting.JsonMediaTypeFormatter());


            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }
    }
}
