using _4Sure.API.API;
using Octokit;
using _4Sure.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4Sure.API.Models;
using _4Sure.API.DataAccess;

namespace _4Sure.API.Controllers
{

    public class SearchController : ApiController
    {
        private ISearchService _searchService;
        private IStorageService _storageService;

        public SearchController(ISearchService searchService, IStorageService storageService)
        {
            _searchService = searchService;
            _storageService = storageService;

        }

        [HttpPost]
        [Route("/search/SearchUsers")]
        public ObjectResult SearchUsers(string username)
        {
            // WHEN A SEARCH REQ IS SENT, SEE IF IT EXISITS IN THE DB FIRST
            // IF SO, AND THAT REQUEST IS FROM TODAY, RETURN THE RESULT, 
            // OTHERWISE GO GET IT FROM THE GIT
            APIResult<string> result = null;
            UserSearchDBO userSearchDBO = _storageService.selectUsersList(username);
            try
            {
                // TODO make configurable
                if (userSearchDBO != null && userSearchDBO.searchDate.Date.Day == DateTime.Now.Day)
                {
                    result = new APIResult<string>()
                    {
                        StatusCode = 200,
                        Message = "Successfully found List of users",
                        Body = userSearchDBO.jsonObj
                    };
                }
                else if (result == null || string.IsNullOrEmpty(result.Body))
                {
                    result = _searchService.GetGitUserList(username);
                    //TODO notify storage
                    _storageService.storeUsersList(username, result.Body);
                }

                if (result != null)
                {
                    return HttpResponse(result);
                }
                else
                {
                    return InternalServerError("Error getting results");
                }
            }
            catch (Exception e)
            {
                return InternalServerError("Error getting results");
            }


        }
        [HttpPost]
        [Route("/search/SearchUserActivity")]
        public ObjectResult SearchUserActivity(string username)
        {
            // WHEN A SEARCH REQ IS SENT, SEE IF IT EXISITS IN THE DB FIRST
            // IF SO, AND THAT REQUEST IS FROM TODAY, RETURN THE RESULT, 
            // OTHERWISE GO GET IT FROM THE GIT
            APIResult<string> result = null;
            try
            {
                ActivitySearchDBO activitySearch = _storageService.selectActivities(username);
                if (activitySearch != null && activitySearch.searchDate.Date.Day == DateTime.Now.Day)
                {
                    result = new APIResult<string>()
                    {
                        StatusCode = 200,
                        Message = "Successfully found List of users",
                        Body = activitySearch.jsonObj
                    };
                }
                else if(result==null || string.IsNullOrEmpty(result.Body))
                {
                    result = _searchService.GetGitUser(username);
                    //TODO notify storage
                    _storageService.storeUsersList(username, result.Body);
                }
                if (result != null)
                {
                    return HttpResponse(result);
                }
                else
                {
                    return InternalServerError("Error getting results");
                }
            }
            catch (Exception e)
            {
                return InternalServerError("Error getting results");
            }
        }
    }
}
