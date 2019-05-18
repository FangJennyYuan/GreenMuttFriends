﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Backend;

namespace WebApplication1.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult Index()
        {
            var myViewModel = new LibraryViewModel();

            myViewModel.PhotoViewModel = PhotoBackend.Instance.Index();

            return View(myViewModel);
        }

        public ActionResult PhotoDetail()
        {
            return View();
        }
    }
}