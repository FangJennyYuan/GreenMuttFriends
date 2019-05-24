using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TotalPhotosTakenModel
    {
        // The Clinic Name
        public string Clinic { get; set; }

        // Recorded Date Time photo was taken
        public DateTime Date { get; set; }

        // The total photos taken
        public int Value { get; set; }

        //Total distinct users
        public int UserCount { get; set; }
    }
}