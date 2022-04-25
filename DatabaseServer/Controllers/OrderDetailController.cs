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
    public class OrderDetailController : ApiController
    {
        public IHttpActionResult Get()
        {
            var orderDetails = new Repository<OrderDetail>().Get().ToList();
            return Json(GeneralHelper.GetMessage<OrderDetail>(orderDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{orderDetails.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var orderDetail = await new Repository<OrderDetail>().GetById(id);
            var retVal = (object)orderDetail ?? new { };
            return Json(GeneralHelper.GetMessage<OrderDetail>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetByOrderId(string orderId)
        {
            var orderDetails = new Repository<OrderDetail>().GetByProperty("OrderId", orderId);
            return Json(GeneralHelper.GetMessage<OrderDetail>(orderDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        public IHttpActionResult GetViewByOrderId(int orderId)
        {
            var orderDetails = new Repository<VwOrderDetails>().GetByProperty("OrderId", orderId);
            return Json(GeneralHelper.GetMessage<VwOrderDetails>(orderDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(OrderDetail orderDetail)
        {
            var retVal = await new Repository<OrderDetail>().Add(orderDetail);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<OrderDetail> orderDetails)
        {
            var retVal = await new Repository<OrderDetail>().AddList(orderDetails);
            return Json(retVal);
        }

        [HttpPut]
        public IHttpActionResult Update(OrderDetail orderDetail)
        {
            var retVal = new Repository<OrderDetail>().Update(orderDetail);
            return Json(GeneralHelper.GetMessage<OrderDetail>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateList([FromBody] List<OrderDetail> orderDetails)
        {
            var retVal = await new Repository<OrderDetail>().UpdateList(orderDetails);
            return Json(GeneralHelper.GetMessage<OrderDetail>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }
    }
}