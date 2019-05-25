using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Backend;

namespace WebApplication1.Controllers
{
    public class ImpactDashboardController : Controller
    {
        // GET: ImpactDashboard
        public ActionResult Index()
        {
            var myViewModel = new ImpactViewModel();
            myViewModel.UserViewModel = UserBackend.Instance.Index();
            
            return View(myViewModel);
        }
    }
}