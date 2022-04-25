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
    public class RegionController : ApiController
    {
        public IHttpActionResult Get()
        {
            var regions = new Repository<Region>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Region>(regions, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{regions.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var region = await new Repository<Region>().GetById(id);
            var retVal = (object)region ?? new { };
            return Json(GeneralHelper.GetMessage<Region>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetByCountryId(int countryId)
        {
            var regions = new Repository<Region>().GetByProperty("CountryId", countryId);
            return Json(GeneralHelper.GetMessage<Region>(regions, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
    }
}