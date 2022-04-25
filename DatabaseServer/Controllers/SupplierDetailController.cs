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
    public class SupplierDetailController : ApiController
    {

        public IHttpActionResult Get()
        {
            var supplierDetails = new Repository<VwSupplierDetail>().Get().ToList();
            return Json(GeneralHelper.GetMessage<VwSupplierDetail>(supplierDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{supplierDetails.Count} Adet Kayıt Bulundu."));
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            var supplierDetail = await new Repository<SupplierDetail>().GetById(id);
            var retVal = (object)supplierDetail ?? new { };
            return Json(GeneralHelper.GetMessage<SupplierDetail>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        public IHttpActionResult GetCustomerDetailListByCustomerId(int customerId)
        {
            var supplierDetails = new Repository<VwSupplierDetail>().GetByProperty("CustomerId", customerId).ToList();
            return Json(GeneralHelper.GetMessage<VwSupplierDetail>(supplierDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{supplierDetails.Count} Adet Kayıt Bulundu."));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(SupplierDetail supplierDetail)
        {
            var retVal = await new Repository<SupplierDetail>().Add(supplierDetail);
            return Json(retVal);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(SupplierDetail supplierDetail)
        {
            var retVal = await new Repository<SupplierDetail>().Update(supplierDetail);
            return Json(GeneralHelper.GetMessage<SupplierDetail>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<SupplierDetail>().Delete(id);
            return Json(GeneralHelper.GetMessage<SupplierDetail>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }

    }
}
