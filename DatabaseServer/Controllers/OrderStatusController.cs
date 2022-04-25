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
    public class OrderStatusController : ApiController
    {
        public IHttpActionResult Get()
        {
            var orderStatuses = new Repository<OrderStatus>().Get().ToList();
            return Json(GeneralHelper.GetMessage<OrderStatus>(orderStatuses, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{orderStatuses.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var orderStatus = await new Repository<OrderStatus>().GetById(id);
            var retVal = (object)orderStatus ?? new { };
            return Json(GeneralHelper.GetMessage<OrderStatus>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(OrderStatus orderStatus)
        {
            var retVal = await new Repository<OrderStatus>().Add(orderStatus);
            //return Json(retVal);


            return Json(GeneralHelper.GetMessage<OrderStatus>(new[] { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"1 Adet Kayıt Güncellendi..."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(OrderStatus orderStatus)
        {
           var i = await new Repository<OrderStatus>().Update(orderStatus);
            //return Json(retVal);

            return Json(GeneralHelper.GetMessage<OrderStatus>(new []{i}, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success,$"{i} Adet Kayıt Güncellendi..."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<OrderStatus>().Delete(id);
            return Json(GeneralHelper.GetMessage<OrderStatus>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}