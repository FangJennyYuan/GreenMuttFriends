using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    /// <summary>
    /// In Memory Implementation of a User data store
    /// </summary>
    public class UserRepositoryMock : IUserRepository
    {
        public List<UserModel> MyData = new List<UserModel>();

        /// <summary>
        /// Constructor for User Repository
        /// </summary>
        public UserRepositoryMock()
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
        public UserModel Create(UserModel data)
        {
            MyData.Add(data);
            return data;
        }

        /// <summary>
        /// Return the requested log item from the data store
        /// if not found, return null
        /// </summary>
        /// <param name="id">the item to find</param>
        /// <returns>the item from the datastore, or null</returns>
        public UserModel Read(String id)
        {
            // Get the first instance of the record
            var dataset = MyData.First(m => m.ID == id);
            return dataset;
        }

        /// <summary>
        /// Update the item in the data store
        /// use the ID from the item passed in to find the item and then update it
        /// </summary>
        /// <param name="data">the item to update</param>
        /// <returns>the updated item</returns>
        public UserModel Update(UserModel data)
        {
            // Get the first instance of the record
            var dataset = Read(data.ID);
            if (dataset == null)
            {
                return null;
            }

            dataset.Update(data);
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
            var dataset = Read(id);
            if (dataset == null)
            {
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Return all items in the data store
        /// </summary>
        /// <returns>a list of all the items in the data store</returns>
        public List<UserModel> Index()
        {
            return MyData;
        }

        /// <summary>
        /// Sets Initial Seed Data
        /// </summary>
        public void Initialize()
        {
            // Read in data from csv
            ReadCSVData();

            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/19/2019"), Value = 4, Installs = 1, ValidPhotoCount = 5, PhotoRetakeCount = 4 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/20/2019"), Value = 5, Installs = 2, ValidPhotoCount = 6, PhotoRetakeCount = 2 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/21/2019"), Value = 6, Installs = 0, ValidPhotoCount = 7, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/22/2019"), Value = 6, Installs = 0, ValidPhotoCount = 7, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/23/2019"), Value = 3, Installs = 2, ValidPhotoCount = 4, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/24/2019"), Value = 2, Installs = 2, ValidPhotoCount = 3, PhotoRetakeCount = 2 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/25/2019"), Value = 3, Installs = 1, ValidPhotoCount = 4, PhotoRetakeCount = 3 });

            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/19/2019"), Value = 12, Installs = 1, ValidPhotoCount = 13, PhotoRetakeCount = 2 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/20/2019"), Value = 4, Installs = 0, ValidPhotoCount = 7, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/21/2019"), Value = 8, Installs = 1, ValidPhotoCount = 10, PhotoRetakeCount = 4 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/22/2019"), Value = 8, Installs = 0, ValidPhotoCount = 11, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/23/2019"), Value = 7, Installs = 3, ValidPhotoCount = 5, PhotoRetakeCount = 7 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/24/2019"), Value = 9, Installs = 5, ValidPhotoCount = 7, PhotoRetakeCount = 9 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/25/2019"), Value = 8, Installs = 4, ValidPhotoCount = 9, PhotoRetakeCount = 8 });

            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/19/2019"), Value = 2, Installs = 2, ValidPhotoCount = 3, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/20/2019"), Value = 3, Installs = 1, ValidPhotoCount = 4, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/21/2019"), Value = 4, Installs = 3, ValidPhotoCount = 5, PhotoRetakeCount = 2 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/22/2019"), Value = 5, Installs = 1, ValidPhotoCount = 6, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/23/2019"), Value = 4, Installs = 2, ValidPhotoCount = 6, PhotoRetakeCount = 3 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/24/2019"), Value = 5, Installs = 3, ValidPhotoCount = 7, PhotoRetakeCount = 2 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/25/2019"), Value = 5, Installs = 3, ValidPhotoCount = 8, PhotoRetakeCount = 1 });

            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/19/2019"), Value = 8, Installs = 3, ValidPhotoCount = 12, PhotoRetakeCount = 3 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/20/2019"), Value = 10, Installs = 4, ValidPhotoCount = 14, PhotoRetakeCount = 3 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/21/2019"), Value = 11, Installs = 3, ValidPhotoCount = 15, PhotoRetakeCount = 2 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/22/2019"), Value = 11, Installs = 2, ValidPhotoCount = 18, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/23/2019"), Value = 12, Installs = 4, ValidPhotoCount = 19, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/24/2019"), Value = 14, Installs = 5, ValidPhotoCount = 20, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/25/2019"), Value = 15, Installs = 5, ValidPhotoCount = 20, PhotoRetakeCount = 0 });

            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/26/2019"), Value = 4, Installs = 3, ValidPhotoCount = 5, PhotoRetakeCount = 3 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/27/2019"), Value = 5, Installs = 2, ValidPhotoCount = 6, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/28/2019"), Value = 3, Installs = 3, ValidPhotoCount = 4, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/29/2019"), Value = 0, Installs = 0, ValidPhotoCount = 0, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/30/2019"), Value = 0, Installs = 0, ValidPhotoCount = 0, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/31/2019"), Value = 2, Installs = 0, ValidPhotoCount = 2, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/01/2019"), Value = 2, Installs = 1, ValidPhotoCount = 1, PhotoRetakeCount = 3 });

            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/26/2019"), Value = 11, Installs = 1, ValidPhotoCount = 13, PhotoRetakeCount = 3 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/27/2019"), Value = 4, Installs = 0, ValidPhotoCount = 7, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/28/2019"), Value = 8, Installs = 1, ValidPhotoCount = 10, PhotoRetakeCount = 4 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/29/2019"), Value = 8, Installs = 0, ValidPhotoCount = 11, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/30/2019"), Value = 8, Installs = 3, ValidPhotoCount = 5, PhotoRetakeCount = 7 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/31/2019"), Value = 9, Installs = 5, ValidPhotoCount = 7, PhotoRetakeCount = 9 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/01/2019"), Value = 4, Installs = 4, ValidPhotoCount = 3, PhotoRetakeCount = 5 });

            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/26/2019"), Value = 6, Installs = 2, ValidPhotoCount = 8, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/27/2019"), Value = 7, Installs = 1, ValidPhotoCount = 8, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/28/2019"), Value = 8, Installs = 0, ValidPhotoCount = 7, PhotoRetakeCount = 3 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/29/2019"), Value = 7, Installs = 0, ValidPhotoCount = 9, PhotoRetakeCount = 2 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/30/2019"), Value = 7, Installs = 1, ValidPhotoCount = 9, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/31/2019"), Value = 8, Installs = 2, ValidPhotoCount = 8, PhotoRetakeCount = 3 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/01/2019"), Value = 2, Installs = 1, ValidPhotoCount = 2, PhotoRetakeCount = 1 });

            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/26/2019"), Value = 8, Installs = 3, ValidPhotoCount = 11, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/27/2019"), Value = 10, Installs = 4, ValidPhotoCount = 12, PhotoRetakeCount = 2 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/28/2019"), Value = 9, Installs = 3, ValidPhotoCount = 13, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/29/2019"), Value = 11, Installs = 2, ValidPhotoCount = 15, PhotoRetakeCount = 0 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/30/2019"), Value = 12, Installs = 4, ValidPhotoCount = 16, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/31/2019"), Value = 14, Installs = 5, ValidPhotoCount = 17, PhotoRetakeCount = 1 });
            MyData.Add(new UserModel { Clinic = "Ijora Clinic", Date = DateTime.Parse("05/01/2019"), Value = 3, Installs = 5, ValidPhotoCount = 3, PhotoRetakeCount = 0 });




            // sort data in order by date
            OrderByDate();
        }


        /// <summary>
        /// Sorts the dataset to order by Date (descending)
        /// </summary>
        private void OrderByDate()
        {
            MyData.Sort((x, y) => y.Date.CompareTo(x.Date));
        }

        /// <summary>
        /// Adds new UserModel objects to dataset based on input from csv file
        /// </summary>
        private void ReadCSVData()
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/App_Data/user_data.csv");
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader))
                {
                    var records = csv.GetRecords<UserModel>();

                    foreach (var item in records)
                    {
                        MyData.Add(new UserModel
                        {
                            Clinic = item.Clinic,
                            Date = item.Date,
                            Value = item.Value
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}