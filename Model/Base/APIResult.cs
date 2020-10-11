using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Model.Base
{
    public class APIResult
    {
        public static object ResultSuccessStatus = new
        {
            Code = 200,
            Message = "Success"
        };

        public static object ResultNotFoundStatus = new
        {
            Code = 404,
            Message = "Not Found"
        };

        public static object ResultInternalErrorStatus = new
        {
            Code = 500,
            Message = "Internal Server Error"
        };

        public static object ErrorResult(HttpStatusCode code, string errMsg)
        {
            return new
            {
                Result = new
                {
                    Status = new
                    {
                        Code = code,
                        Message = errMsg
                    },
                }
            };
        }
    }
}
