using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akqa.MarsRover.Web.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            TempData.Clear();
            return View();
        }

        public ActionResult About()
        {
            TempData.Clear();
            return View();
        }

    }
}
