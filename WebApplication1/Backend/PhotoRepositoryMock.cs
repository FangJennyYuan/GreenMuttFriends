﻿using System;
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
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = false, RecordedDateTime = new DateTime(2019, 5, 10, 12, 0, 52),
                PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4",
                ImageURL = "/Content/img/photo/tblur1.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = false, RecordedDateTime = new DateTime(2019, 5, 1, 17, 12, 5),
                PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4",
                ImageURL = "/Content/img/photo/tblur2.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = true, Bilirubin = "25", RecordedDateTime = new DateTime(2019, 4, 27, 10, 8, 49),
                PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = true, Bilirubin = "15", RecordedDateTime = new DateTime(2019, 4, 28, 7, 3, 12),
                PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = false, RecordedDateTime = new DateTime(2019, 5, 2, 20, 5, 34),
                PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4",
                ImageURL = "/Content/img/photo/tblur1.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = false,  RecordedDateTime = new DateTime(2019, 4, 19, 11, 54, 8),
                PhoneNumber = "815-992-0000", UserID = "010", DeviceType = "Samsung Buddy", OSVersion = "3.4",
                ImageURL = "/Content/img/photo/tblur2.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Ijora Clinic", ResultIsValid = true, Bilirubin = "20", RecordedDateTime = new DateTime(2019, 5, 12, 13, 30, 3),
                PhoneNumber = "815-991-1111", UserID = "003", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t6.png"
            });

            // Other clinic data
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", ResultIsValid = true, Bilirubin = "25", RecordedDateTime = new DateTime(2019, 5, 14, 12, 37, 43),
                PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t5.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", ResultIsValid = true, Bilirubin = "10", RecordedDateTime = new DateTime(2019, 5, 18, 15, 22, 19),
                PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Katsina Clinic", ResultIsValid = true, Bilirubin = "15", RecordedDateTime = new DateTime(2019, 4, 22, 16, 0, 54),
                PhoneNumber = "719-991-1447", UserID = "005", DeviceType = "Tecno Mobile", OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", ResultIsValid = true, Bilirubin = "5", RecordedDateTime = new DateTime(2019, 4, 29, 1, 12, 32),
                PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", ResultIsValid = true, Bilirubin = "20", RecordedDateTime = new DateTime(2019, 5, 16, 9, 42, 12),
                PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel { ClinicName = "Mashegu Clinic", ResultIsValid = true, Bilirubin = "25", RecordedDateTime = new DateTime(2019, 5, 16, 8, 53, 43),
                PhoneNumber = "815-901-1334", UserID = "006", DeviceType = "Samsung Buddy", OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 25, 8, 23, 43),
                PhoneNumber = "815-901-1334",
                UserID = "006",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 25, 10, 21, 40),
                PhoneNumber = "815-901-1334",
                UserID = "006",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 25, 11, 34, 8),
                PhoneNumber = "815-901-1334",
                UserID = "006",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 25, 10, 0, 54),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 24, 11, 2, 13),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 24, 16, 0, 54),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 24, 10, 1, 4),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 25, 11, 2, 3),
                PhoneNumber = "815-991-1111",
                UserID = "003",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = false,
                RecordedDateTime = new DateTime(2019, 5, 25, 10, 10, 2),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 24, 16, 32, 3),
                PhoneNumber = "815-991-1111",
                UserID = "003",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t5.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = false,
                RecordedDateTime = new DateTime(2019, 5, 24, 12, 0, 52),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "30",
                RecordedDateTime = new DateTime(2019, 5, 24, 15, 12, 3),
                PhoneNumber = "815-991-1111",
                UserID = "003",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = false,
                RecordedDateTime = new DateTime(2019, 5, 23, 12, 0, 52),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = false,
                RecordedDateTime = new DateTime(2019, 5, 25, 17, 21, 2),
                PhoneNumber = "813-777-1122",
                UserID = "013",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 25, 14, 50, 1),
                PhoneNumber = "813-777-1122",
                UserID = "013",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 24, 16, 30, 3),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 25, 10, 22, 12),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 24, 15, 0, 50),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 22, 12, 20, 10),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 24, 5, 11, 30),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t2.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 23, 17, 33, 12),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 24, 15, 0, 50),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 23, 15, 0, 50),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 23, 15, 0, 50),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 24, 10, 2, 44),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 24, 1, 30, 50),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 24, 15, 0, 50),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 25, 15, 0, 50),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 22, 16, 3, 40),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 22, 10, 33, 12),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 21, 16, 6, 35),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 20, 9, 20, 10),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });

            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 24, 14, 26, 6),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 21, 8, 20, 44),
                PhoneNumber = "815-992-0000",
                UserID = "01",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 22, 14, 26, 6),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "30",
                RecordedDateTime = new DateTime(2019, 5, 20, 8, 55, 24),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 16, 15, 0, 50),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 17, 12, 30, 50),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 18, 15, 0, 50),
                PhoneNumber = "860-346-9901",
                UserID = "012",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 19, 11, 33, 0),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 20, 9, 29, 1),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 21, 8, 39, 10),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t5.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 21, 12, 30, 27),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 24, 13, 13, 40),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 23, 14, 11, 16),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 24, 11, 50, 42),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 24, 14, 10, 22),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 24, 15, 11, 7),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 16, 10, 34, 5),
                PhoneNumber = "815-901-1334",
                UserID = "006",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "35",
                RecordedDateTime = new DateTime(2019, 5, 17, 9, 0, 31),
                PhoneNumber = "815-901-1334",
                UserID = "006",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 21, 14, 10, 22),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 22, 14, 10, 22),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "30",
                RecordedDateTime = new DateTime(2019, 5, 23, 9, 12, 50),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 23, 16, 2, 41),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 17, 12, 10, 5),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 18, 13, 19, 20),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 19, 10, 8, 7),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t5.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "30",
                RecordedDateTime = new DateTime(2019, 5, 19, 12, 10, 14),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 20, 10, 30, 9),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 21, 7, 10, 4),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 22, 7, 10, 6),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t5.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "30",
                RecordedDateTime = new DateTime(2019, 5, 23, 15, 3, 7),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 23, 15, 11, 7),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Katsina Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 24, 6, 55, 16),
                PhoneNumber = "719-991-1447",
                UserID = "005",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 19, 12, 30, 29),
                PhoneNumber = "815-991-1111",
                UserID = "003",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = false,
                RecordedDateTime = new DateTime(2019, 5, 19, 11, 10, 52),
                PhoneNumber = "815-992-0000",
                UserID = "010",
                DeviceType = "Samsung Buddy",
                OSVersion = "3.4",
                ImageURL = "/Content/img/photo/tblur14.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 19, 10, 53, 43),
                PhoneNumber = "860-541-0007",
                UserID = "019",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/tblur14.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 20, 11, 2, 1),
                PhoneNumber = "860-541-0007",
                UserID = "019",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 21, 9, 45, 6),
                PhoneNumber = "860-541-0007",
                UserID = "019",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t2.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 22, 13, 15, 8),
                PhoneNumber = "860-541-0007",
                UserID = "019",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 23, 12, 50, 3),
                PhoneNumber = "860-541-0007",
                UserID = "019",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/tblur14.png"
            });

            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 19, 10, 2, 43),
                PhoneNumber = "860-209-8891",
                UserID = "020",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.0",
                ImageURL = "/Content/img/photo/t4.png"
            });

            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 22, 12, 50, 3),
                PhoneNumber = "860-209-8891",
                UserID = "020",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t2.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 23, 9, 21, 3),
                PhoneNumber = "860-209-8891",
                UserID = "020",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t6.png"
            });

            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 18, 12, 50, 3),
                PhoneNumber = "860-209-8891",
                UserID = "020",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t2.png"
            });

            dataset.Add(new PhotoModel
            {
                ClinicName = "Mashegu Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 17, 10, 5, 0),
                PhoneNumber = "860-209-8891",
                UserID = "020",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 17, 13, 2, 43),
                PhoneNumber = "815-991-1111",
                UserID = "003",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "30",
                RecordedDateTime = new DateTime(2019, 5, 18, 16, 32, 21),
                PhoneNumber = "815-991-1111",
                UserID = "003",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 19, 13, 2, 41),
                PhoneNumber = "815-991-1111",
                UserID = "003",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "20",
                RecordedDateTime = new DateTime(2019, 5, 20, 13, 00, 6),
                PhoneNumber = "815-991-1111",
                UserID = "003",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t5.png"
            });

            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 19, 12, 10, 3),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t3.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = false,
                RecordedDateTime = new DateTime(2019, 5, 20, 13, 2, 43),
                PhoneNumber = "842-305-4391",
                UserID = "021",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t2.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "15",
                RecordedDateTime = new DateTime(2019, 5, 21, 11, 0, 8),
                PhoneNumber = "842-305-4391",
                UserID = "021",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t5.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "25",
                RecordedDateTime = new DateTime(2019, 5, 22, 13, 2, 43),
                PhoneNumber = "842-305-4391",
                UserID = "021",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t2.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "30",
                RecordedDateTime = new DateTime(2019, 5, 22, 9, 20, 44),
                PhoneNumber = "842-305-4391",
                UserID = "021",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = false,
                RecordedDateTime = new DateTime(2019, 5, 23, 10, 40, 2),
                PhoneNumber = "842-305-4391",
                UserID = "021",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t6.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "30",
                RecordedDateTime = new DateTime(2019, 5, 22, 13, 20, 17),
                PhoneNumber = "842-305-4391",
                UserID = "021",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t4.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Ijora Clinic",
                ResultIsValid = true,
                Bilirubin = "10",
                RecordedDateTime = new DateTime(2019, 5, 23, 9, 55, 36),
                PhoneNumber = "842-305-4391",
                UserID = "021",
                DeviceType = "Samsung Buddy",
                OSVersion = "4.1",
                ImageURL = "/Content/img/photo/t2.png"
            });
            dataset.Add(new PhotoModel
            {
                ClinicName = "Rawayau Clinic",
                ResultIsValid = true,
                Bilirubin = "5",
                RecordedDateTime = new DateTime(2019, 5, 21, 12, 10, 3),
                PhoneNumber = "866-284-4120",
                UserID = "014",
                DeviceType = "Tecno Mobile",
                OSVersion = "5.1",
                ImageURL = "/Content/img/photo/t1.png"
            });
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