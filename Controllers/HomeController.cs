using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PocketDDD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.Cache.SetNoTransforms();
            return View();
        }

        public ActionResult online()
        {
            return View("Index");
        }
    }
}
