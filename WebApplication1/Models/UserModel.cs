using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserModel
    {
        // The ID of the record
        public string ID { get; set; } = Guid.NewGuid().ToString();

        // The user's Clinic Name
        public string Clinic { get; set; }

        public DateTime Date { get; set; }

        public int Value { get; set; }
        /// <summary>
        /// Constructor for User Model
        /// Calls to Initialize to set initial settings
        /// </summary>
        public UserModel()
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
        public bool Update(UserModel data)
        {
            if (data == null)
            {
                return false;
            }

            Clinic = data.Clinic;
            Date = data.Date;
            Value = data.Value;

            return true;
        }

        internal object Remove(UserModel dataset)
        {
            throw new NotImplementedException();
        }
    }
}