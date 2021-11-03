using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.DataAccess
{
    public class ActivitySearchDBO
    {
        public int id { get; set; }
        public string searchQuery { get; set; }
        public string jsonObj { get; set; }
        public DateTime searchDate { get; set; }
        public ActivitySearchDBO() { }
    }
}
