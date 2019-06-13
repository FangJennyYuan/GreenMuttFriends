using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Backend;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            dynamic mymodel = new HomeViewModel();
            mymodel.UserViewModel = UserBackend.Instance.Index();
            mymodel.PhotoViewModel = PhotoBackend.Instance.Index();
            return View(mymodel);
        }
    }
}