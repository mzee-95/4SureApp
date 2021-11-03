using _4Sure.API.API;
using _4Sure.API.Models;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.Services
{
    public interface ISearchService
    {
        public APIResult<string> GetGitUser(string username);
        public APIResult<string> GetGitUserList(string username);
    }
}
