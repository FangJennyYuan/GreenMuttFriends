using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HomeViewModel
    {
        // List of User information
        public UserViewModel UserViewModel { get; set; }

        // List of Photo information
        public PhotoViewModel PhotoViewModel { get; set; }
    }
}