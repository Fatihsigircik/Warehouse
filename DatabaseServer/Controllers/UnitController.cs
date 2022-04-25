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
    public class UnitController : ApiController
    {
        public IHttpActionResult Get()
        {
            var units = new Repository<Unit>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Unit>(units, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{units.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var unit = await new Repository<Unit>().GetById(id);
            var retVal = (object)unit ?? new { };
            return Json(GeneralHelper.GetMessage<Unit>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Unit unit)
        {
            var retVal = await new Repository<Unit>().Add(unit);
            //return Json(retVal);


            return Json(GeneralHelper.GetMessage<Unit>(new[] { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"1 Adet Kayıt Güncellendi..."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(Unit unit)
        {
            var i = await new Repository<Unit>().Update(unit);
            //return Json(retVal);

            return Json(GeneralHelper.GetMessage<Unit>(new[] { i }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{i} Adet Kayıt Güncellendi..."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<Unit>().Delete(id);
            return Json(GeneralHelper.GetMessage<Unit>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}