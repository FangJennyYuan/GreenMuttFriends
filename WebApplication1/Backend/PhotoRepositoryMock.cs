using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    /// <summary>
    /// In Memory Implementation of a Photo data store
    /// </summary>
    public class PhotoRepositoryMock : IPhotoRepository
    {
        public List<PhotoModel> dataset = new List<PhotoModel>();

        /// <summary>
        /// Constructor for Photo Repository
        /// </summary>
        public PhotoRepositoryMock()
        {
            // Call for Sead data to be created
            Initialize();
        }

        /// <summary>
        /// Add the log item to the data store
        /// </summary>
        /// <param name="data">
        /// The new log item to add to the data store
        /// </param>
        /// <returns>return the passed in log item</returns>
        public PhotoModel Create(PhotoModel data)
        {
            dataset.Add(data);
            return data;
        }

        /// <summary>
        /// Return the requested log item from the data store
        /// if not found, return null
        /// </summary>
        /// <param name="id">the item to find</param>
        /// <returns>the item from the datastore, or null</returns>
        public PhotoModel Read(String id)
        {
            // Get the first instance of the record
            var myData = dataset.First(m => m.ID == id);
            return myData;
        }

        /// <summary>
        /// Update the item in the data store
        /// use the ID from the item passed in to find the item and then update it
        /// </summary>
        /// <param name="data">the item to update</param>
        /// <returns>the updated item</returns>
        public PhotoModel Update(PhotoModel data)
        {
            // Get the first instance of the record
            var myData = dataset.First(m => m.ID == data.ID);
            if (myData == null)
            {
                return null;
            }

            myData.Update(data);
            return data;
        }

        /// <summary>
        /// Remove the item from the data store
        /// Look it up by ID, if found, remove it, and return true
        /// else return false
        /// </summary>
        /// <param name="id">the item to remove by ID</param>
        /// <returns>true if removed</returns>
        public Boolean Delete(String id)
        {
            // Get the first instance of the record
            var myData = dataset.First(m => m.ID == id);
            if (myData == null)
            {
                return false;
            }

            var myResult = dataset.Remove(myData);
            return myResult;
        }

        /// <summary>
        /// Return all items in the data store
        /// </summary>
        /// <returns>a list of all the items in the data store</returns>
        public List<PhotoModel> Index()
        {
            return dataset;
        }

        /// <summary>
        /// Sets Initial Seed Data
        /// </summary>
        public void Initialize()
        {
            // Ijora Clinic data for scenario
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", Bilirubin = "15", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", Bilirubin = "5", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", Bilirubin = "10", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", Bilirubin = "25", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", Bilirubin = "15", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", Bilirubin = "10", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", Bilirubin = "15", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", Bilirubin = "20", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1" });

            // Other clinic data
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", Bilirubin = "25", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0" });
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", Bilirubin = "10", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0" });
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", Bilirubin = "15", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0" });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", Bilirubin = "5", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1" });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", Bilirubin = "10", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1" });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", Bilirubin = "25", RecordedDateTime = DateTime.UtcNow, PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1" });

            //TODO add data for invalid results (need new boolean field in photo model?)
            

        }
    }
}