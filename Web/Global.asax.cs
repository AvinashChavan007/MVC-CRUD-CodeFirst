using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();

            var httpException = exception as HttpException;

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "HttpError404";
                        break;
                    case 500:
                        // server error
                        action = "HttpError500";
                        break;
                    default:
                        action = "GeneralError";
                        break;
                }

                // clear error on server
                Server.ClearError();
                while (exception.InnerException != null) exception = exception.InnerException;
                _logger.Error(exception.Message);


                Response.Redirect($"~/Error/{action}?message={exception.Message}");


            }
            else
            {
                while (exception.InnerException != null) exception = exception.InnerException;
                Server.ClearError();
                var encoded = HttpUtility.HtmlEncode(exception.Message).Replace(@":", " ").Replace(Environment.NewLine, " ");
                _logger.Error(exception.Message);

                Response.Redirect($"~/Error/GeneralError?message={encoded}");

            }
        }
    }
}
