using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AccountModel
    {
        // The ID of the record
        public string ID { get; set; } = Guid.NewGuid().ToString();

        // The Account Name
        public string AccountName { get; set; }

        // Whether the user is logged in or not
        public bool isAccountLoggedIn { get; set; } = false;

        /// <summary>
        /// Constructor for Account Model
        /// Calls to Initialize to set initial settings
        /// </summary>
        public AccountModel()
        {
            Initialize();
        }

        /// <summary>
        /// Intialize
        /// Sets default values, such as DateTime as needed by the system
        /// </summary>
        public void Initialize()
        {
            // None right now...
        }

        /// <summary>
        /// Update fields passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(AccountModel data)
        {
            if (data == null)
            {
                return false;
            }

            AccountName = data.AccountName;
            isAccountLoggedIn = data.isAccountLoggedIn;

            return true;
        }
    }
}