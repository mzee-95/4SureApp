using _4Sure.API.DataAccess;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.Middleware
{
    public class BaseMiddleware
    {

        protected void AddDapperConnection(HttpContext httpContext, DapperConnection dapperConnection, string key = "DAPPER_CONNECTION")
        {
            if (dapperConnection == null)
                throw new Exception("dapperConnection cannot be null"); // TODO: Create proper exception
            httpContext.Items.Add(key, dapperConnection);
        }

        protected DapperConnection GetDapperConnection(HttpContext httpContext, string key = "DAPPER_CONNECTION")
        {
            return (DapperConnection)httpContext.Items[key];
        }

    }

}
