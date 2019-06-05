using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    public static class DataHelper
    {

        public static int TotalPhotosByDayAndClinic(PhotoViewModel data)
        {
            var totalPhotosByDay = data.PhotoList.GroupBy(m => new { m.ClinicName, m.RecordedDateTime.DayOfYear })
                    .Select(group => new
                    {
                        ClinicName = group.Key,
                        Count = group.Count()

                    })
                    .ToList();
            return 0;
            
        }
    }
}