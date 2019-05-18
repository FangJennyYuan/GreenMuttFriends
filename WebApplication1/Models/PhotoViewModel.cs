using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PhotoViewModel
    {
        /// <summary>
        /// List of Photos
        /// </summary>
        public List<PhotoModel> PhotoList { get; set; } = new List<PhotoModel>();
    }
}