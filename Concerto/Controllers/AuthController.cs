using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Concerto.Handler;
using Concerto.Helper;
using Concerto.Helper.APIAttribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Base;
using Newtonsoft.Json.Linq;

namespace Concerto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireApplicationKeyHeader]
    public class AuthController : ControllerBase
    {
        private readonly IAuthHandler authHandler;

        public AuthController(IAuthHandler authHandler)
        {
            this.authHandler = authHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(JObject body)
        {
            try
            {
                return Ok(await authHandler.Login(body));
            }
            catch (BadRequestException ex)
            {
                return Ok(APIResult.ErrorResult(HttpStatusCode.BadRequest, ex.Message));
            }
            catch (Exception ex)
            {
                return Ok(APIResult.ErrorResult(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(JObject body)
        {
            try
            {
                return Ok(await authHandler.Register(body));
            }
            catch (BadRequestException ex)
            {
                return Ok(APIResult.ErrorResult(HttpStatusCode.BadRequest, ex.Message));
            }
            catch (Exception ex)
            {
                return Ok(APIResult.ErrorResult(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}