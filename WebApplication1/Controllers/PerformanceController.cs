using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Backend;
using System.Collections;

namespace WebApplication1.Controllers
{
    public class PerformanceController : Controller
    {

        // GET: Performance Photos
        public ActionResult Index()
        {
            var myViewModel = new PerformanceViewModel();

            myViewModel.PhotoViewModel = PhotoBackend.Instance.Index();

            return View(myViewModel);
        }
    }
}