using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Index()
        {
            return View();
        }
    }
}