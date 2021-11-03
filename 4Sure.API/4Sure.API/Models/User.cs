using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.Models
{
    public class User
    {
        public string login { get; set; }
        public string avatarUrl { get; set; }
        public string email { get; set; }
        public int followers { get; set; }
        public string bio { get; set; }

        public User(string login, string avatarUrl, string email, int followers, string bio)
        {
            this.login = login;
            this.avatarUrl = avatarUrl;
            this.email = email;
            this.followers = followers;
        }

    }
}
