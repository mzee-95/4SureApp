using _4Sure.API.Config;
using _4Sure.API.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _4Sure.API.Middleware
{
    public class ConnectionMiddleware : BaseMiddleware
    {

        private readonly RequestDelegate _next;

        public ConnectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IOptions<SQLSettings> connectionSettings)
        {
            DapperConnection dapperConnection = new DapperConnection(new SqlConnection(connectionSettings.Value.ConnectionString));

            try
            {
                dapperConnection.Open();
                AddDapperConnection(context, dapperConnection);
                //AddProcessServerSettings(context, processServerSettings.Value);
                await _next.Invoke(context);
                return;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return;
            }
            finally
            {
                dapperConnection.Close();
            }
        }
    }
}

