using _4Sure.API.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.Services
{
    public class APIService
    {
        protected DapperConnection Connection { get; set; }

        public APIService(DapperConnection _dapperConnection)
        {
            Connection = _dapperConnection;
        }
    }
}
