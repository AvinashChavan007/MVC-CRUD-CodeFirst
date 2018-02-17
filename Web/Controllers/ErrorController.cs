using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult HttpError500(string message)
        {
            var errorModel = new ErrorViewModel(message);
            return View(errorModel);
        }

        public ActionResult HttpError404(string message)
        {
            var errorModel = new ErrorViewModel(message);
            return View(errorModel);
        }

        public ActionResult GeneralError(string message)
        {
            var errorModel = new ErrorViewModel(message);
            return View(errorModel);
        }
    }
}