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
            var myData = Read(data.ID);
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
            var myData = Read(id);
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
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = true, Bilirubin = "15", RecordedDateTime = new DateTime(2019, 5, 18, 16, 32, 3),
                PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL ="/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = false, RecordedDateTime = new DateTime(2019, 5, 10, 12, 0, 52),
                PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4",
                ImageURL ="/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = false, RecordedDateTime = new DateTime(2019, 5, 1, 17, 12, 5),
                PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4",
                ImageURL ="/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = true, Bilirubin = "25", RecordedDateTime = new DateTime(2019, 4, 27, 10, 8, 49),
                PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL ="/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = true, Bilirubin = "15", RecordedDateTime = new DateTime(2019, 4, 28, 7, 3, 12),
                PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = false, RecordedDateTime = new DateTime(2019, 5, 2, 20, 5, 34),
                PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4",
                ImageURL = "/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = false,  RecordedDateTime = new DateTime(2019, 4, 19, 11, 54, 8),
                PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4",
                ImageURL = "/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = true, Bilirubin = "20", RecordedDateTime = new DateTime(2019, 5, 12, 13, 30, 3),
                PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/Mumu.jpg" });

            // Other clinic data
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", ResultIsValid = true, Bilirubin = "25", RecordedDateTime = new DateTime(2019, 5, 14, 12, 37, 43),
                PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0",
                ImageURL = "/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", ResultIsValid = true, Bilirubin = "10", RecordedDateTime = new DateTime(2019, 5, 18, 15, 22, 19),
                PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0",
                ImageURL = "/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", ResultIsValid = true, Bilirubin = "15", RecordedDateTime = new DateTime(2019, 4, 22, 16, 0, 54),
                PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0",
                ImageURL = "/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", ResultIsValid = true, Bilirubin = "5", RecordedDateTime = new DateTime(2019, 4, 29, 1, 12, 32),
                PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", ResultIsValid = true, Bilirubin = "10", RecordedDateTime = new DateTime(2019, 5, 16, 9, 42, 12),
                PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/Mumu.jpg" });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", ResultIsValid = true, Bilirubin = "25", RecordedDateTime = new DateTime(2019, 5, 17, 8, 53, 43),
                PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/Mumu.jpg" });

            // Sort dataset by RecordedDateTime
            OrderByDate();
        }

        /// <summary>
        /// Sorts the dataset to order by RecordedDateTime (descending)
        /// </summary>
        private void OrderByDate()
        {
            dataset.Sort((x, y) => y.RecordedDateTime.CompareTo(x.RecordedDateTime));
        }
    }
}