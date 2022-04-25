using DAL;
using DatabaseServer.Helper;
using DatabaseServer.Models;
using System.Net;
using System.Web.Http;

namespace DatabaseServer.Controllers
{
    public class TokenController : ApiController
    {
        //[AllowAnonymous]
        //public string Get(string username, string password)
        //{
        //    if (CheckUser(username, password))
        //        return JwtManager.GenerateToken(username, 30);
        //    throw new HttpResponseException(HttpStatusCode.Unauthorized);
        //}

        [AllowAnonymous]
        public string Post(LoginUser user)
        {
            if (!CheckUser(user.UserName, user.Password))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            user.IpAddress = GeneralHelper.GetClientIp();
            return JwtManager.GenerateToken(user, 30);
        }

        private static bool CheckUser(string username, string password)
        {
            var users = new Repository<User>().GetByProperty("UserName", username);
            if (users.Count != 1)
                return false;
            return password == users[0].Password;
        }
    }
}