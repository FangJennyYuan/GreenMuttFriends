using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Backend;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    public class PhotoBackend
    {
        #region SingletonPattern
        private static volatile PhotoBackend instance;
        private static object syncRoot = new object();

        private PhotoBackend() { }

        public static PhotoBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PhotoBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private IPhotoRepository repository = new PhotoRepositoryMock();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public PhotoModel Create(PhotoModel data)
        {
            var myData = repository.Create(data);
            return myData;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhotoModel Read(string id)
        {
            var myData = repository.Read(id);
            return myData;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public PhotoModel Update(PhotoModel data)
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
        ///  Returns the List of Photos
        /// </summary>
        /// <returns></returns>
        public LibraryViewModel Index()
        {
            var myData = new LibraryViewModel();
            myData.PhotoList = repository.Index();

            return myData;
        }
    }
}