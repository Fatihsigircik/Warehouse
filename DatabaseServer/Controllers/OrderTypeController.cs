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
    public class OrderTypeController : ApiController
    {
        public IHttpActionResult Get()
        {
            var orderTypes = new Repository<OrderType>().Get().ToList();
            return Json(GeneralHelper.GetMessage<OrderType>(orderTypes, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{orderTypes.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var orderType = await new Repository<OrderType>().GetById(id);
            var retVal = (object)orderType ?? new { };
            return Json(GeneralHelper.GetMessage<OrderType>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
    }
}