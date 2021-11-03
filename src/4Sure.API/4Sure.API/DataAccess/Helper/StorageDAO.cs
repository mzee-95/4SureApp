using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.DataAccess.Helper
{
    public class StorageDAO : ApiDAO
    {
        public StorageDAO(DapperConnection dapperConnection) : base(dapperConnection) { }

        public UserSearchDBO SelectUserSearchByLogin(string searchQuery)
        {
            string sqlSelectByID = @"
                SELECT *
                FROM UserSearch
                WHERE searchQuery = @searchQuery;
              ";

            return Connection.QuerySingle<UserSearchDBO>(sqlSelectByID, new { searchQuery = searchQuery });
        }

        public ActivitySearchDBO SelectActivitySearchByLogin(string searchQuery)
        {
            string sqlSelectByID = @"
                SELECT *
                FROM ActivitySearch
                WHERE searchQuery = @searchQuery;
              ";

            return Connection.QuerySingle<ActivitySearchDBO>(sqlSelectByID, new { searchQuery = searchQuery });
        }

        public bool InsertUserSearchResult(string searchQuery, string jsonObj)
        {
            string sqlInsertSearch = @"
            DELETE FROM UserSearch WHERE searchQuery = @searchQuery;

            INSERT INTO [UserSearch]
            (searchQuery, jsonObj, searchDate )
            VALUES (@searchQuery, @jsonObj, @searchDate);
            SELECT SCOPE_IDENTITY();
          ";

            try
            {
                Connection.QuerySingle<int>(sqlInsertSearch, new
                {
                    searchQuery = searchQuery,
                    jsonObj = jsonObj,
                    searchDate = DateTime.Now
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool InsertActivitySearchResult(string searchQuery, string jsonObj)
        {
            string sqlInsertSearch = @"
             DELETE FROM ActivitySearch WHERE searchQuery = @searchQuery;

            INSERT INTO [ActivitySearch]
            (searchQuery, jsonObj, searchDate )
            VALUES (@searchQuery, @jsonObj, @searchDate);
            SELECT SCOPE_IDENTITY();
          ";

            try
            {
                Connection.QuerySingle<int>(sqlInsertSearch, new
                {
                    searchQuery = searchQuery,
                    jsonObj = jsonObj,
                    searchDate = DateTime.Now
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
