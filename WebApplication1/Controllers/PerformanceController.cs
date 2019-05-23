using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Backend;


namespace WebApplication1.Controllers
{
    public class PerformanceController : Controller
    {
        // GET: Performance
        public ActionResult Index()
        {
            //Model with totals
            var myViewModel = new List<TotalPhotosTakenModel>();

            //Raw photos from backend
            var photosRaw = new PhotoViewModel();
            photosRaw = PhotoBackend.Instance.Index();


            //Calculate totals for each clinic on each day
            var clinicTotals = new Dictionary<string, int>();
            foreach (var item in photosRaw.PhotoList)
            {
                int currentCount = 0;
                var clinicAndDate = item.ClinicName + "_" + item.RecordedDateTime.ToShortDateString();
                clinicTotals.TryGetValue(clinicAndDate, out currentCount);
                clinicTotals[clinicAndDate] = currentCount + 1;
            }

            //Add aggregate photo totals to model by date and clinic
            foreach (KeyValuePair<string, int> entry in clinicTotals)
            {
                string[] clinicByDate = entry.Key.Split('_');
                myViewModel.Add(
                    new TotalPhotosTakenModel
                    {
                        Clinic = clinicByDate[0],
                        Date = DateTime.Parse(clinicByDate[1]),
                        Value = entry.Value
                    }
                );
            }
            return View(myViewModel);
        }
    }
}