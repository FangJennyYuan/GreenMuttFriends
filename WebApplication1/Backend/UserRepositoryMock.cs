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
        public List<UserModel> dataset = new List<UserModel>();

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
            dataset.Add(data);
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
            var myData = dataset.First(m => m.ID == id);
            return myData;
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
        public List<UserModel> Index()
        {
            return dataset;
        }

        /// <summary>
        /// Sets Initial Seed Data
        /// </summary>
        public void Initialize()
        {
            dataset.Add(new UserModel { ClinicName = "Ijora Clinic"});

        }
    }
}