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
            myData.Add(new AppUserDataModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/19/2019"), Value = 10 });
            myData.Add(new AppUserDataModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/20/2019"), Value = 8 });
            myData.Add(new AppUserDataModel {Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/21/2019"), Value = 7});
            myData.Add(new AppUserDataModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/22/2019"), Value = 8 });
            myData.Add(new AppUserDataModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/23/2019"), Value = 6 });
            myData.Add(new AppUserDataModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/24/2019"), Value = 8 });
            myData.Add(new AppUserDataModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/25/2019"), Value = 9 });

            myData.Add(new AppUserDataModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/19/2019"), Value = 12 });
            myData.Add(new AppUserDataModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/20/2019"), Value = 4 });
            myData.Add(new AppUserDataModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/21/2019"), Value = 8 });
            myData.Add(new AppUserDataModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/22/2019"), Value = 8 });
            myData.Add(new AppUserDataModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/23/2019"), Value = 7 });
            myData.Add(new AppUserDataModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/24/2019"), Value = 9 });
            myData.Add(new AppUserDataModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/25/2019"), Value = 8 });

            myData.Add(new AppUserDataModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/19/2019"), Value = 8 });
            myData.Add(new AppUserDataModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/20/2019"), Value = 9 });
            myData.Add(new AppUserDataModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/21/2019"), Value = 7 });
            myData.Add(new AppUserDataModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/22/2019"), Value = 10 });
            myData.Add(new AppUserDataModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/23/2019"), Value = 8 });
            myData.Add(new AppUserDataModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/24/2019"), Value = 8 });
            myData.Add(new AppUserDataModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/25/2019"), Value = 9 });

            myData.Add(new AppUserDataModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/19/2019"), Value = 8 });
            myData.Add(new AppUserDataModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/20/2019"), Value = 10 });
            myData.Add(new AppUserDataModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/21/2019"), Value = 11 });
            myData.Add(new AppUserDataModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/22/2019"), Value = 11 });
            myData.Add(new AppUserDataModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/23/2019"), Value = 12 });
            myData.Add(new AppUserDataModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/24/2019"), Value = 14 });
            myData.Add(new AppUserDataModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/25/2019"), Value = 15 });

            return View(myData);
        }
    }
}