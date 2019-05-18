using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    /// <summary>
    /// Define an interface which contains the methods for the Photo repository.
    /// All CRUDi aspects
    /// </summary>
    public interface IPhotoRepository
    {
        PhotoModel Create(PhotoModel data);
        PhotoModel Read(String id);
        PhotoModel Update(PhotoModel data);
        Boolean Delete(String id);
        List<PhotoModel> Index();
    }
}