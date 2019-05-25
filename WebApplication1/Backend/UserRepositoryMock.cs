using System;
using System.Collections.Generic;
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


            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/19/2019"), Value = 10 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/20/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/21/2019"), Value = 7 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/22/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/23/2019"), Value = 6 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/24/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Rawayau Clinic", Date = DateTime.Parse("05/25/2019"), Value = 9 });

            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/19/2019"), Value = 12 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/20/2019"), Value = 4 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/21/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/22/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/23/2019"), Value = 7 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/24/2019"), Value = 9 });
            MyData.Add(new UserModel { Clinic = "Mashegu Clinic", Date = DateTime.Parse("05/25/2019"), Value = 8 });

            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/19/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/20/2019"), Value = 9 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/21/2019"), Value = 7 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/22/2019"), Value = 10 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/23/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/24/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Katsina Clinic", Date = DateTime.Parse("05/25/2019"), Value = 9 });

            MyData.Add(new UserModel { Clinic = "Ijowa Clinic", Date = DateTime.Parse("05/19/2019"), Value = 8 });
            MyData.Add(new UserModel { Clinic = "Ijowa Clinic", Date = DateTime.Parse("05/20/2019"), Value = 10 });
            MyData.Add(new UserModel { Clinic = "Ijowa Clinic", Date = DateTime.Parse("05/21/2019"), Value = 11 });
            MyData.Add(new UserModel { Clinic = "Ijowa Clinic", Date = DateTime.Parse("05/22/2019"), Value = 11 });
            MyData.Add(new UserModel { Clinic = "Ijowa Clinic", Date = DateTime.Parse("05/23/2019"), Value = 12 });
            MyData.Add(new UserModel { Clinic = "Ijowa Clinic", Date = DateTime.Parse("05/24/2019"), Value = 14 });
            MyData.Add(new UserModel { Clinic = "Ijowa Clinic", Date = DateTime.Parse("05/25/2019"), Value = 15 });
        }
    }
}