using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DAL;
using DatabaseServer.Filters;
using DatabaseServer.Helper;

namespace DatabaseServer.Controllers
{
    [JwtAuthentication]
    public class CustomerDetailController : ApiController
    {
        public IHttpActionResult Get()
        {
            var customersDetails = new Repository<VwCustomerDetail>().Get().ToList();
            return Json(GeneralHelper.GetMessage<VwCustomerDetail>(customersDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{customersDetails.Count} Adet Kayıt Bulundu."));
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            var customerDetail = await new Repository<CustomerDetail>().GetById(id);
            var retVal = (object)customerDetail ?? new { };
            return Json(GeneralHelper.GetMessage<CustomerDetail>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        public IHttpActionResult GetCustomerDetailListByCustomerId(int customerId)
        {
            var customersDetails = new Repository<VwCustomerDetail>().GetByProperty("CustomerId",customerId).ToList();
            return Json(GeneralHelper.GetMessage<VwCustomerDetail>(customersDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{customersDetails.Count} Adet Kayıt Bulundu."));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CustomerDetail customerDetail)
        {
            var retVal = await new Repository<CustomerDetail>().Add(customerDetail);
            return Json(retVal);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(CustomerDetail customerDetail)
        {
            var retVal = await new Repository<CustomerDetail>().Update(customerDetail);
            return Json(GeneralHelper.GetMessage<CustomerDetail>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<CustomerDetail>().Delete(id);
            return Json(GeneralHelper.GetMessage<CustomerDetail>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}
