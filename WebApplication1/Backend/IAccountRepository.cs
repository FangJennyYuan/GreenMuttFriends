using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Backend
{
    /// <summary>
    /// Define an interface which contains the methods for the Account repository.
    /// All CRUDi aspects
    /// </summary>
    public interface IAccountRepository
    {
        AccountModel Create(AccountModel data);
        AccountModel Read(String id);
        AccountModel Update(AccountModel data);
        Boolean Delete(String id);
        List<AccountModel> Index();
    }
}