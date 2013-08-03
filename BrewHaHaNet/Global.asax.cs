using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RouteConfig;
using Ninject;
using Ninject.Web.Common;

namespace BrewHaHaNet {
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : NinjectHttpApplication {

    public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
      filters.Add(new HandleErrorAttribute());
    }

    private void RegisterServices(IKernel kernel) {

    }

	

    protected new void Application_Start() {
      AreaRegistration.RegisterAllAreas();


      Ninject.StandardKernel kernel;
      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      AuthConfig.RegisterAuth();
    }

    protected override Ninject.IKernel CreateKernel() {
      var kernel = new StandardKernel();
      RegisterServices(kernel);
      return kernel;
    }
  }
}