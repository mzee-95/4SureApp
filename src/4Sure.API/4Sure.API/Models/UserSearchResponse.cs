using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.Models
{
    public class UserSearchResponse
    {
        public List<User> users = new List<User>();

        public UserSearchResponse(IReadOnlyList<Octokit.User> users)
        {
            foreach(var u in users)
            {
                this.users.Add(new User(u.Login, u.AvatarUrl, u.Email!=null? u.Email: "", u.Followers, u.Bio));
            }
        }
    }
}
