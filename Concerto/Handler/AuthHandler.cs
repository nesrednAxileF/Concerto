using Model.Base;
using Model.Subdomains.AuthSubdomain;
using Newtonsoft.Json.Linq;
using Service.Modules.API.AuthModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concerto.Handler
{
    public interface IAuthHandler
    {
        Task<object> Login(JObject body);
        Task<object> Register(JObject body);
    }
    public class AuthHandler : IAuthHandler
    {
        private readonly IAuthService authService;

        public AuthHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<object> Login(JObject body)
        {
            try
            {
                UserLogin user = body.Value<JObject>("UserLogin").ToObject<UserLogin>();
                User userRes = await authService.CheckLoginData(user);
                return new
                {
                    Result = new
                    {
                        Status = APIResult.ResultSuccessStatus,
                        User = userRes
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> Register(JObject body)
        {
            try
            {
                User user = body.Value<JObject>("User").ToObject<User>();
                user = await authService.RegisterUser(user);
                return new
                {
                    Result = new
                    {
                        Status = APIResult.ResultSuccessStatus,
                        User = user
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
