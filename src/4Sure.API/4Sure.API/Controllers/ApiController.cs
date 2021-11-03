using _4Sure.API.API;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _4Sure.API.Controllers
{
    public class ApiController : ControllerBase
    {

        #region Status code: 2** 
        protected ObjectResult Ok<T>(T body)
        {
            return base.Ok(body); ;
        }
        protected ObjectResult Created<T>(T body)
        {
            return base.Created("", body);
        }
        protected ObjectResult Accepted<T>(T body)
        {
            return base.Accepted(body);
        }
        #endregion Status code: 2** 

        #region Status code: 4** 
        protected ObjectResult BadRequest(string message)
        {
            return base.BadRequest(message);
        }
        protected ObjectResult Unauthorized(string message)
        {
            return base.Unauthorized(message);
        }

        protected ObjectResult Forbidden(string message)
        {
            return base.StatusCode((int)HttpStatusCode.Forbidden, message);
        }

        protected ObjectResult Conflict(string message)
        {
            return base.Conflict(message);
        }
        #endregion Status code: 4** 

        #region Status code: 5** 
        protected ObjectResult InternalServerError(string message)
        {
            return base.StatusCode((int)HttpStatusCode.InternalServerError, message);
        }
        protected ObjectResult BadGateWay(string message)
        {
            return base.StatusCode((int)HttpStatusCode.BadGateway, message);
        }
        protected ObjectResult ServiceUnavailable(string message)
        {
            return base.StatusCode((int)HttpStatusCode.ServiceUnavailable, message);
        }
        #endregion Status code: 5** 

        protected ObjectResult HttpResponse<T>(APIResult<T> apiResult)
        {
            switch (apiResult.StatusCode)
            {
                case (200):
                    return Ok(apiResult.Body);
                case 201:
                    return Created(apiResult.Body);
                case 202:
                    return Accepted(apiResult.Body);
                case 400:
                    return BadRequest(apiResult.Message);
                case 401:
                    return Unauthorized(apiResult.Message);
                case 403:
                    return Forbidden(apiResult.Message);
                case 404:
                    return NotFound(apiResult.Message);
                case 409:
                    return Conflict(apiResult.Message);
                case 502:
                    return BadGateWay(apiResult.Message);
                case 503:
                    return ServiceUnavailable(apiResult.Message);
                case 500:
                default:
                    return String.IsNullOrEmpty(apiResult.Message) ? InternalServerError("Something went wrong. Please try again or contact us for support.") : InternalServerError(apiResult.Message);
            }
        }
    }

}
