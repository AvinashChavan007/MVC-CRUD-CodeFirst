using System;
using System.Web.Mvc;
using Biz.Interfaces;
using Biz.Services;
using Microsoft.Ajax.Utilities;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        #region Properties
        private readonly IAccountService _accountService;

        #endregion

        #region Constructor
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public AccountController()
        {
            _accountService = new AccountService();
        }
        #endregion

        #region Methods


        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            var test = _accountService.GetAll();

            throw new NullReferenceException();
            return View();
        }
        #endregion
    }
}