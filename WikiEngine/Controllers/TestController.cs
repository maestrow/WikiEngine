using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WikiEngine.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(string view)
        {
            return View(view);
        }
    }
}