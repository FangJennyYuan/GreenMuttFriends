using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ImpactDashboardController : Controller
    {
        // GET: ImpactDashboard
        public ActionResult Index()
        {
            var myData = new List<AppUserDataModel>();

            myData.Add(
                new AppUserDataModel
                {
                    Clinic = "Rawayau Clinic",
                    Date = DateTime.Parse("05/19/2019"),
                    Value = 10
                }
                );
            
            return View(myData);
        }
    }
}