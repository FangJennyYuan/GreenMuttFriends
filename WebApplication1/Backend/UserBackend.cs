using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Backend;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    public class UserBackend
    {
        #region SingletonPattern
        private static volatile UserBackend instance;
        private static object syncRoot = new object();

        private UserBackend() { }

        public static UserBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UserBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private IUserRepository repository = new UserRepositoryMock();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UserModel Create(UserModel data)
        {
            var myData = repository.Create(data);
            return myData;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel Read(string id)
        {
            var myData = repository.Read(id);
            return myData;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UserModel Update(UserModel data)
        {
            var myData = repository.Update(data);
            return myData;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var myData = repository.Delete(id);
            return myData;
        }

        /// <summary>
        ///  Returns the List of Users
        /// </summary>
        /// <returns></returns>
        public UserViewModel Index()
        {
            var myData = new UserViewModel();
            myData.UserList = repository.Index();

            return myData;
        }
    }
}