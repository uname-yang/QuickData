using FastDB.Service;
using QuickData.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickData.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFastDB _fastdb;

        public HomeController(IFastDB fastdb)
        {
            _fastdb = fastdb;
        }

        // [BasicAuthorize]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
