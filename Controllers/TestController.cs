using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro.Controllers
{
    
    public class TestController : Controller
    {
        // GET: Test
        [Authorize]
        public ActionResult Test1()
        {
            return View();
        }
        public ActionResult Test2()
        {
            return View();
        }
    }
}