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
    public class SupplierController : ApiController
    {
        public IHttpActionResult Get()
        {
            var suppliers = new Repository<Supplier>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Supplier>(suppliers, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{suppliers.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var supplier = await new Repository<Supplier>().GetById(id);
            var retVal = (object)supplier ?? new { };
            return Json(GeneralHelper.GetMessage<Supplier>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetDetail()
        {
            var customers = new Repository<VwSupplier>().GetByProperty("IsDeleted", false).ToList();
            return Json(GeneralHelper.GetMessage<VwSupplier>(customers, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{customers.Count} Adet Kayıt Bulundu."));
        }

        [HttpGet]
        public IHttpActionResult GetByCode(string code)
        {
            var suppliers = new Repository<Supplier>().GetByProperty("CustomerCode", code);
            return Json(GeneralHelper.GetMessage<Supplier>(suppliers, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Supplier supplier)
        {
            var retVal = await new Repository<Supplier>().Add(supplier);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<Supplier> suppliers)
        {
            var retVal = await new Repository<Supplier>().AddList(suppliers);
            return Json(retVal);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(Supplier supplier)
        {
            var retVal = await new Repository<Supplier>().Update(supplier);
            return Json(GeneralHelper.GetMessage<Supplier>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateList([FromBody] List<Supplier> suppliers)
        {
            var retVal = await new Repository<Supplier>().UpdateList(suppliers);
            return Json(GeneralHelper.GetMessage<Supplier>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var supplier = await new Repository<Supplier>().GetById(id);
            supplier.IsDeleted = true;
            var retVal = await new Repository<Supplier>().UpdateListByFields(
                new List<Supplier>()
                {
                    supplier
                }, "IsDeleted");
            return Json(GeneralHelper.GetMessage<Supplier>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteByCode([FromUri] string code)
        {
            var retVal = await new Repository<Supplier>().DeleteByField("SupplierCode", code);
            return Json(GeneralHelper.GetMessage<Supplier>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}
