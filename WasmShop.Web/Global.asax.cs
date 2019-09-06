using AutoMapper;
using Ninject;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WasmShop.Web.Infrastructure;
using WasmShop.Web.Models;

namespace WasmShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfiguration.Configure();

            ModelBinders.Binders.Add(typeof(CartViewModel), new CartModelBinder());
        }
    }
}