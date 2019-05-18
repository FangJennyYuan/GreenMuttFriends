using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PhotoModel
    {
        // The ID of the record
        public string ID { get; set; } = Guid.NewGuid().ToString();

        // The Clinic Name
        public string ClinicName { get; set; }

        // The total serum bilirubin result, as a string
        public string Bilirubin { get; set; }

        // Recorded Date Time photo was taken
        public DateTime RecordedDateTime { get; set; }

        // Phone number as a string
        public string PhoneNumber { get; set; }

        // UserID as a string
        public string UserID { get; set; }

        // Device type as a string
        public string DeviceType { get; set; }

        // App Version as a string
        public string OSVersion { get; set; }

        /// <summary>
        /// Constructor for Photo Model
        /// Calls to Initialize to set initial settings
        /// </summary>
        public PhotoModel()
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
        public bool Update(PhotoModel data)
        {
            if (data == null)
            {
                return false;
            }

            ClinicName = data.ClinicName;
            Bilirubin = data.Bilirubin;
            RecordedDateTime = data.RecordedDateTime;
            PhoneNumber = data.PhoneNumber;
            UserID = data.UserID;
            DeviceType = data.DeviceType;
            OSVersion = data.OSVersion;

            return true;
        }
    }
}