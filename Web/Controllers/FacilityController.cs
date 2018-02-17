using System.IO;
using System.Linq;
using System.Web.Mvc;
using Biz.Interfaces;
using Core.Domains;
using Core.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class FacilityController : Controller
    {

        #region Properties

        private readonly IFacilityService _facilityService;

        #endregion

        #region Constructor

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        #endregion

        // GET: Facility
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]

        public ActionResult GetUnitForm(int? id)
        {
            if (id == null)
            {

                return View("_FacilityForm", new FacilityViewModel { Id = 0, Name = " ", Landmark = " ", Address = " ", Address2 = " ", City = " ", State = " ", ZipCode = " ", IsActive = true });


            }
            var facility = _facilityService.GetById((int)id);
            var model = new FacilityViewModel(facility);

            return PartialView("_FacilityForm", model);

        }
        #region DataTable

        [HttpPost]
        public ActionResult FacilityTable(DTParameters param, bool? activeFilter = null)
        {
            var tableData = _facilityService.GetAllDataTable(param.SortOrder, param.Search?.Value, activeFilter).ToList();
            ;
            var skipData = tableData.Skip(param.Start).Take(param.Length);
            var result = new
            {
                draw = param.Draw,
                data = skipData.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Landmark,
                    x.Address,
                    x.Address2,
                    x.City,
                    x.State,
                    x.ZipCode,
                    x.IsActive
                }),
                recordsFiltered = tableData.Count,
                recordsTotal = tableData.Count
            };

            return Json(result);

        }

        #endregion

        #region Form Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveFacility(FacilityViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { reload = false, partialViewData = RenderViewToString("_FacilityForm", model) });
            }


            var facility = new Facility()
            {
                Id = model.Id,
                Name = model.Name,
                Landmark = model.Landmark,
                Address = model.Address,
                Address2 = model.Address2,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                IsActive = model.IsActive
            };
            
            _facilityService.InsertOrUpdate(facility);
            return Json(new { reload = true });
        }

        public string RenderViewToString(string viewPath, object model = null)
        {
            ControllerContext.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindView(ControllerContext, viewPath, null);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ControllerContext.Controller.ViewData, ControllerContext.Controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }

    #endregion
}