using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Backend;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    public class AccountBackend
    {
        #region SingletonPattern
        private static volatile AccountBackend instance;
        private static object syncRoot = new object();

        private AccountBackend() { }

        public static AccountBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new AccountBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private IAccountRepository repository = new AccountRepositoryMock();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public AccountModel Create(AccountModel data)
        {
            var myData = repository.Create(data);
            return myData;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AccountModel Read(string id)
        {
            var myData = repository.Read(id);
            return myData;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public AccountModel Update(AccountModel data)
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
        ///  Returns the List of Accounts
        /// </summary>
        /// <returns></returns>
        public List<AccountModel> Index()
        {
            var myData = repository.Index();
            return myData;
        }

        public AccountModel GetActiveUser()
        {
            var myData = repository.Index().FirstOrDefault();
            return myData;
        }
    }
}