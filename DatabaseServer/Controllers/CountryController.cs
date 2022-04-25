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
    public class CountryController : ApiController
    {
        public IHttpActionResult Get()
        {
            var countries = new Repository<Country>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Country>(countries, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{countries.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var country = await new Repository<Country>().GetById(id);
            var retVal = (object)country ?? new { };
            return Json(GeneralHelper.GetMessage<Country>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
    }
}