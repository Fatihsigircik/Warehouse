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
    public class CityController : ApiController
    {
        public IHttpActionResult Get()
        {
            var cities = new Repository<City>().Get().ToList();
            return Json(GeneralHelper.GetMessage<City>(cities, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{cities.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var city = await new Repository<City>().GetById(id);
            var retVal = (object)city ?? new { };
            return Json(GeneralHelper.GetMessage<City>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpGet]
        public IHttpActionResult GetByCountryId(int countryId)
        {
            var cities = new Repository<City>().GetByProperty("CountryId", countryId);
            return Json(GeneralHelper.GetMessage<City>(cities, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetByRegionId(int regionId)
        {
            var cities = new Repository<City>().GetByProperty("RegionId", regionId);
            return Json(GeneralHelper.GetMessage<City>(cities, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }


        //Veriler yüklenirken kullanıldı

        //[HttpPost]
        //public async Task<IHttpActionResult> PostList([FromBody] List<City> cities)
        //{
        //    var retVal = await new Repository<City>().AddList(cities);
        //    return Json(retVal);
        //}
    }
}