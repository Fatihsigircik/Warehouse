using DAL;
using DatabaseServer.Filters;
using DatabaseServer.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DatabaseServer.Controllers
{
    [JwtAuthentication]
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            var users = new Repository<User>().Get().ToList();
            return Json(GeneralHelper.GetMessage<User>(users, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{users.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await new Repository<User>().GetById(id);
            var retVal = (object)user ?? new { };
            return Json(GeneralHelper.GetMessage<User>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetByUserName(string userName)
        {
            var users = new Repository<User>().GetByProperty("UserName", userName);
            return Json(GeneralHelper.GetMessage<User>(users, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetByUserGroupId(int id)
        {
            var users = new Repository<User>().GetByProperty("UserGroupId", id);
            return Json(GeneralHelper.GetMessage<User>(users, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(User user)
        {
            var retVal = await new Repository<User>().Add(user);
            return Json(retVal);
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> PostList([FromBody] List<User> users)
        //{
        //    var retVal = await new Repository<User>().AddList(users);
        //    return Json(retVal);
        //}

        [HttpPut]
        public IHttpActionResult Update(User user)
        {
            var retVal = new Repository<User>().Update(user);
            return Json(GeneralHelper.GetMessage<User>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        //[HttpPut]
        //public async Task<IHttpActionResult> UpdateList([FromBody] List<User> users)
        //{
        //    var retVal = await new Repository<User>().UpdateList(users);
        //    return Json(GeneralHelper.GetMessage<User>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        //}
    }
}