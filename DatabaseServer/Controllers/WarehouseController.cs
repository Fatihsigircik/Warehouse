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
    public class WarehouseController : ApiController
    {
        public IHttpActionResult Get()
        {
            var warehouses = new Repository<Warehouse>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Warehouse>(warehouses, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{warehouses.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var warehouse = await new Repository<Warehouse>().GetById(id);
            var retVal = (object)warehouse ?? new { };
            return Json(GeneralHelper.GetMessage<Warehouse>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
    }
}