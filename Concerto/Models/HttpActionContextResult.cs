using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Concerto.Models
{
    public class HttpActionContextResult
    {
        public static ContentResult GetContentActionContext(HttpStatusCode httpStatusCode, object Content)
        {
            ContentResult contentResult = new ContentResult
            {
                StatusCode = Convert.ToInt32(httpStatusCode),
                Content = JsonConvert.SerializeObject(Content)
            };
            contentResult.ContentType = "application/json";
            return contentResult;
        }
    }
}
