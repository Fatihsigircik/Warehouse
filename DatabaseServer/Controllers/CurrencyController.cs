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
    public class CurrencyController : ApiController
    {
        public IHttpActionResult Get()
        {
            var currencies = new Repository<Currency>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Currency>(currencies, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{currencies.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var currency = await new Repository<Currency>().GetById(id);
            var retVal = (object)currency ?? new { };
            return Json(GeneralHelper.GetMessage<Currency>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
    }
}