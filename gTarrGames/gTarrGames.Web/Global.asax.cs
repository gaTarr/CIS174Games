using gTarrGames.Domain;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.ViewModels;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace gTarrGames.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ErrorLogOrchestrator _errorLogOrchestrator = new ErrorLogOrchestrator();

        protected void Application_Error(object sender, EventArgs eventArgs)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                string innerEx = "None";
                if (exception.InnerException != null)
                {
                    innerEx = exception.InnerException.ToString();
                }

                _errorLogOrchestrator.CreateError(new ErrorLogViewModel
                {
                    ErrorId = Guid.NewGuid(),
                    ErrorDateTime = DateTime.Now,
                    ErrorMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    InnerExceptions = innerEx
                });
            }

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}
