using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string id = null)
        {
            var myAccountModel = Backend.AccountBackend.Instance.GetActiveUser();
            Backend.AccountBackend.Instance.ToggleUser(myAccountModel);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout(string id = null)
        {
            var myAccountModel = Backend.AccountBackend.Instance.GetActiveUser();
            Backend.AccountBackend.Instance.ToggleUser(myAccountModel);
            return RedirectToAction("Index", "Home");
        }
    }
}