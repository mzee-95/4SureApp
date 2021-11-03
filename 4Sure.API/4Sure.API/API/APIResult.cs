using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Sure.API.API
{
    public class APIResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public APIResult() { }
    }
    public class APIResult<T> : APIResult
    {
        [JsonProperty("body")]
        public T Body { get; set; }
    }
}
