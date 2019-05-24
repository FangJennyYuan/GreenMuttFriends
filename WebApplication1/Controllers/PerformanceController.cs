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
        // GET: Performance
        public ActionResult Index()
        {
            //Model with totals
            var myViewModel = new List<TotalPhotosTakenModel>();

            //Raw photos from backend
            var photosRaw = new PhotoViewModel();
            photosRaw = PhotoBackend.Instance.Index();


            //Calculate photo totals for each clinic on each day
            var clinicPhotoTotals = new Dictionary<string, int>();
            foreach (var item in photosRaw.PhotoList)
            {
                int currentPhotoCount = 0;
                var clinicAndDate = item.ClinicName + "_" + item.RecordedDateTime.ToShortDateString();
                clinicPhotoTotals.TryGetValue(clinicAndDate, out currentPhotoCount);
                clinicPhotoTotals[clinicAndDate] = currentPhotoCount + 1;
            }

            //Add aggregate photo totals to model by date and clinic
            foreach (KeyValuePair<string, int> entry in clinicPhotoTotals)
            {
                string[] clinicByDate = entry.Key.Split('_');
                string clinic = clinicByDate[0];
                string date = clinicByDate[1];

                //Query data to Get the users for this clinic and date
                IEnumerable<PhotoModel> query = photosRaw.PhotoList.Where(
                    c => c.ClinicName == clinic
                    && c.RecordedDateTime.ToShortDateString() == date
                );

                //Get distinct user count
                List<string> users  = (from t in query
                 select t.UserID).Distinct().ToList();
                int userCount = users.Count;

                myViewModel.Add(
                    new TotalPhotosTakenModel
                    {
                        Clinic = clinic,
                        Date = DateTime.Parse(date),
                        Value = entry.Value,
                        UserCount = userCount
                    }
                );
            }
            return View(myViewModel);
        }
    }
}