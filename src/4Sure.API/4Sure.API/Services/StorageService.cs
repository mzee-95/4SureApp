using _4Sure.API.Config;
using _4Sure.API.DataAccess;
using _4Sure.API.DataAccess.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.Services
{
    public class StorageService : APIService,  IStorageService
    {
        private IHttpContextAccessor httpContextAccessor;
        public StorageService(IHttpContextAccessor _httpContextAccessor)
          : base((DapperConnection)_httpContextAccessor.HttpContext.Items["DAPPER_CONNECTION"])
        {
 
            //httpContextAccessor = _httpContextAccessor;
        }

        public bool storeActivities(string searchQuery, string userActivityJson)
        {
            StorageDAO storageDAO = new StorageDAO(Connection);
            return storageDAO.InsertActivitySearchResult(searchQuery, userActivityJson);
        }

        public bool storeUsersList(string searchQuery, string userJson)
        {
            StorageDAO storageDAO = new StorageDAO(Connection);
            return storageDAO.InsertActivitySearchResult(searchQuery, userJson);
        }

        public UserSearchDBO selectUsersList(string searchQuery)
        {
            StorageDAO storageDAO = new StorageDAO(Connection);
            return storageDAO.SelectUserSearchByLogin(searchQuery);
        }

        public ActivitySearchDBO selectActivities(string searchQuery)
        {
            StorageDAO storageDAO = new StorageDAO(Connection);
            return storageDAO.SelectActivitySearchByLogin(searchQuery);
        }
    }
}
