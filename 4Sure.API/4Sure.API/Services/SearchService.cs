using _4Sure.API.API;
using _4Sure.API.Config;
using _4Sure.API.Models;
using Microsoft.Extensions.Options;
using Octokit;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
//using System.Text.Json;
using System.Threading.Tasks;

namespace _4Sure.API.Services
{
    public class SearchService : ISearchService
    {
        IOptions<GitSettings> _gitSettings;

        public SearchService(IOptions<GitSettings> gitSettings)
        {
            _gitSettings = gitSettings;
        }
        /*
            create new GitHub cliet which we will use to
            get the list of possible users to return to FE
        */
        public APIResult<string> GetGitUserList(string username)
        {
            
            var github = new GitHubClient(new ProductHeaderValue(_gitSettings.Value.applicationName));
            var usr = GetUserList(username, github);
            UserSearchResponse users = new UserSearchResponse(usr.Items);
            JsonSerializer srs = new JsonSerializer();
            string result = srs.Serialize(users);
            //string result = "[{\"username\":\"mzee test 1\"},{\"username\":\"mzee test 2\"}]";
            return new APIResult<string>()
            {
                StatusCode = 200,
                Message = "Successfully found List of users",
                Body = result
            };
        }
        /*
             create new GitHub cliet which we will use to get the
             user detials and activities to send back to the FE
        */
        public APIResult<string> GetGitUser(string username)
        {
            
            var github = new GitHubClient(new ProductHeaderValue(_gitSettings.Value.applicationName));
            var user = GetUser(username, github);
            var activity = GetUserActivity(user, github);

            UserResponse userResponse = new UserResponse(user, activity);
            JsonSerializer srs = new JsonSerializer();
            string result = srs.Serialize(userResponse);
            return new APIResult<string>()
            {
                StatusCode = 200,
                Message = "Successfully found user",
                Body = result
            };
        }

        private Octokit.User GetUser(string username, GitHubClient github)
        {
            Octokit.User user =  github.User.Get(username).Result;
            return user;

        }

        private IReadOnlyList<Activity> GetUserActivity(Octokit.User user, GitHubClient github)
        {
            ApiOptions options = new ApiOptions();
            options.PageCount = 30;
            options.PageSize = 1;
            return  github.Activity.Events.GetAllUserPerformed(user.Login, options).Result;
        }

        private  SearchUsersResult GetUserList(string username, GitHubClient github)
        {
            var resp =  github.Search.SearchUsers(new SearchUsersRequest(username) { Page = 1, PerPage = 500 }).Result;
            return resp;


        }
    }
}
