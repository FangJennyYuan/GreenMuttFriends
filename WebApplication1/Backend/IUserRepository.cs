using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    /// <summary>
    /// Define an interface which contains the methods for the User repository.
    /// All CRUDi aspects
    /// </summary>
    public interface IUserRepository
    {
        UserModel Create(UserModel data);
        UserModel Read(String id);
        UserModel Update(UserModel data);
        Boolean Delete(String id);
        List<UserModel> Index();
    }
}