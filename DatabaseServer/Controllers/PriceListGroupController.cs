using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DAL;
using DatabaseServer.Filters;
using DatabaseServer.Helper;

namespace DatabaseServer.Controllers
{
    [JwtAuthentication]
    public class PriceListGroupController : ApiController
    {
        public IHttpActionResult Get()
        {
            var priceListGroups = new Repository<PriceListGroup>().Get().ToList();
            return Json(GeneralHelper.GetMessage<PriceListGroup>(priceListGroups, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{priceListGroups.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var priceListGroup = await new Repository<PriceListGroup>().GetById(id);
            var retVal = (object)priceListGroup ?? new { };
            return Json(GeneralHelper.GetMessage<PriceListGroup>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpGet]
        public IHttpActionResult GetByCountryId(int groupType)
        {
            var priceListGroups = new Repository<PriceListGroup>().GetByProperty("GroupType", groupType);
            return Json(GeneralHelper.GetMessage<PriceListGroup>(priceListGroups, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
    }
}
