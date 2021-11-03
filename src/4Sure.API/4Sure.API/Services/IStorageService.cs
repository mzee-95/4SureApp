using _4Sure.API.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.Services
{
    public interface IStorageService
    {
        public bool storeActivities(string searchQuery, string userActivityJson);
        public bool storeUsersList(string searchQuery, string userJson);
        public UserSearchDBO selectUsersList(string searchQuery);
        public ActivitySearchDBO selectActivities(string searchQuery);
    }
}
