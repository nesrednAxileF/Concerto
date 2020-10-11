using Concerto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Concerto.Helper.APIAttribute
{
    public class RequireApplicationKeyHeader : ActionFilterAttribute
    {
        const string NOAPPKEY_ERROR = "No ApplicationKey passed in request header";
        const string INVALIDAPPKEY_ERROR = "Invalid ApplicationKey passed";
        const string INTERNAL_ERROR = "Internal Error";

        private bool IsKeyValid(string ApplicationKey)
        {
            return true;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues value;
            if (context.HttpContext.Request.Headers.TryGetValue("ApplicationKey", out value))
            {
                try
                {
                    string ApplicationKey = value.ToString();
                    if (string.IsNullOrEmpty(ApplicationKey))
                    {
                        context.Result = HttpActionContextResult.GetContentActionContext(HttpStatusCode.Forbidden, APIResult.ErrorResult(HttpStatusCode.Forbidden, NOAPPKEY_ERROR));
                    }
                    else
                    {
                        if (!IsKeyValid(ApplicationKey))
                            context.Result = HttpActionContextResult.GetContentActionContext(HttpStatusCode.Forbidden, APIResult.ErrorResult(HttpStatusCode.Forbidden, INVALIDAPPKEY_ERROR));
                    }
                }
                catch (Exception ex)
                {
                    context.Result = HttpActionContextResult.GetContentActionContext(HttpStatusCode.Forbidden, APIResult.ErrorResult(HttpStatusCode.Forbidden, INTERNAL_ERROR + ". " + ex.Message));
                }
            }
            else
            {
                context.Result = HttpActionContextResult.GetContentActionContext(HttpStatusCode.Forbidden, APIResult.ErrorResult(HttpStatusCode.Forbidden, NOAPPKEY_ERROR));
            }
        }
    }
}
