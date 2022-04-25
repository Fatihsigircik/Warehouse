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
    public class UserGroupController : ApiController
    {
        public IHttpActionResult Get()
        {
            var userGroups = new Repository<UserGroup>().Get().ToList();
            return Json(GeneralHelper.GetMessage<UserGroup>(userGroups, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{userGroups.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var userGroup = await new Repository<UserGroup>().GetById(id);
            var retVal = (object)userGroup ?? new { };
            return Json(GeneralHelper.GetMessage<UserGroup>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetByUserGroupName(string name)
        {
            var userGroups = new Repository<UserGroup>().GetByProperty("UserGroupName", name);
            return Json(GeneralHelper.GetMessage<UserGroup>(userGroups, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(UserGroup userGroup)
        {
            var retVal = await new Repository<UserGroup>().Add(userGroup);
            return Json(retVal);
        }

        [HttpPut]
        public IHttpActionResult Update(UserGroup userGroup)
        {
            var retVal = new Repository<UserGroup>().Update(userGroup);
            return Json(GeneralHelper.GetMessage<UserGroup>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }
    }
}