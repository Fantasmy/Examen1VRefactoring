using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vueling.Facade.Api.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this view instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = Resource.HP;

            return View();
        }
    }
}
