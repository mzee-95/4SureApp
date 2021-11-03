using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.Models
{
    public class Activities
    {
        public string type { get; set; }
        public string repo { get; set; }
        public string date { get; set; }
        public string id { get; set; }

        public Activities(string type, string repo, string date, string id)
        {
            this.type = type;
            this.repo = repo;
            this.date = date;
            this.id = id;
        }
    }
}
