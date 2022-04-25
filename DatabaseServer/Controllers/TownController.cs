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
    public class TownController : ApiController
    {
        public IHttpActionResult Get()
        {
            var towns = new Repository<Town>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Town>(towns, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{towns.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var town = await new Repository<Town>().GetById(id);
            var retVal = (object)town ?? new { };
            return Json(GeneralHelper.GetMessage<Town>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetByCityId(int cityId)
        {
            var towns = new Repository<Town>().GetByProperty("CityId", cityId);
            return Json(GeneralHelper.GetMessage<Town>(towns.OrderBy(q=>q.Name), Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }


        //Veriler yüklenirken kullanıldı

        //[HttpPost]
        //public async Task<IHttpActionResult> PostList([FromBody] List<Town> towns)
        //{
        //    var retVal = await new Repository<Town>().AddList(towns);
        //    return Json(retVal);
        //}
    }
}