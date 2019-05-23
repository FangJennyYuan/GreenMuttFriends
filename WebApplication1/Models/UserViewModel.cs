using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserViewModel
    {
        /// <summary>
        /// List of Users
        /// </summary>
        public List<UserModel> UserList { get; set; } = new List<UserModel>();

        public List<AppUserDataModel> AppUserList { get; set; } = new List<AppUserDataModel>();
        public List<AppInstallsDataModel> AppInstallList { get; set; } = new List<AppInstallsDataModel>();
    }
}