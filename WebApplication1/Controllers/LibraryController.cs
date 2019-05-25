using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Backend;
using CsvHelper;


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

        public ActionResult PhotoDetail(string id = null)
        {

            // If no ID passed in, jump to the Index page
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var myData = PhotoBackend.Instance.Read(id);
            return View(myData);
        }

        public ActionResult ExportToCSV()
        {
            var myViewModel = new LibraryViewModel();
            myViewModel.PhotoViewModel = PhotoBackend.Instance.Index();
            var myData = myViewModel.PhotoViewModel.PhotoList;

            var ms = new System.IO.MemoryStream();
            var sw = new System.IO.StreamWriter(ms);
            var csvOut = new CsvWriter(sw);

            csvOut.WriteRecords(myData);

            sw.Flush();

            ms.Position = 0;

            string filename = "Visual_Impact_Data_" + DateTime.Now.ToShortDateString() + ".csv";
            return File(ms, "text/csv", filename);
        }
    }
}