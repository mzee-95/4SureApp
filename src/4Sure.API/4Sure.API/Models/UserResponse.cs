using Octokit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _4Sure.API.Models
{
    public class UserResponse
    {
        public User user { get; }
        public List<Activities> activities = new List<Activities>();

        public UserResponse(Octokit.User user, IReadOnlyList<Activity> activities)
        {
            this.user = new User(user.Login, user.AvatarUrl, "", user.Followers, user.Bio);
            foreach(Activity a in activities)
            {
                this.activities.Add(new Activities(a.Type, a.Repo.Url, a.CreatedAt.ToString(), a.Id));
            }
        }
    }
}
