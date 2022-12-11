using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About1()
        {
            
            return View();
        }
        public ActionResult TestConnection()
        {

            return PartialView();
        }
    }
}