using System;
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
    public class CustomerController : ApiController
    {
        public IHttpActionResult Get()
        {
            var customers = new Repository<Customer>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Customer>(customers, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{customers.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var customer = await new Repository<Customer>().GetById(id);
            var retVal = (object)customer ?? new { };
            return Json(GeneralHelper.GetMessage<Customer>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetDetail()
        {
            var customers = new Repository<VwCustomer>().GetByProperty("IsDeleted", false).ToList();
            return Json(GeneralHelper.GetMessage<VwCustomer>(customers, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{customers.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> GetDetail(int skip, int take)
        {

            var customers = await new Repository<VwCustomer>().GetAsync();
            customers = customers.Skip(skip).Take(take).ToList();
            return Json(GeneralHelper.GetMessage<VwCustomer>(customers, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{customers.Count()} Adet Kayıt Bulundu."));


        }

        [HttpGet]
        public IHttpActionResult GetByCode(string code)
        {
            var customers = new Repository<Customer>().GetByProperty("CustomerCode", code);
            return Json(GeneralHelper.GetMessage<Customer>(customers, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        [HttpGet]
        public IHttpActionResult GetByCodeStartWith(string code)
        {
            var customers = new Repository<Customer>().GetByWhereExpression(q=>q.CustomerCode.StartsWith(code));
            return Json(GeneralHelper.GetMessage<Customer>(customers, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(Customer customer)
        {
            var retVal = await new Repository<Customer>().Add(customer);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<Customer> customers)
        {
            var retVal = await new Repository<Customer>().AddList(customers);
            return Json(retVal);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(Customer customer)
        {
            var retVal = await new Repository<Customer>().Update(customer);
            return Json(GeneralHelper.GetMessage<Customer>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateList([FromBody] List<Customer> customers)
        {
            var retVal = await new Repository<Customer>().UpdateList(customers);
            return Json(GeneralHelper.GetMessage<Customer>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var customer = await new Repository<Customer>().GetById(id);
            customer.IsDeleted = true;
            var retVal = await new Repository<Customer>().UpdateListByFields(
                new List<Customer>()
                {
                    customer
                }, "IsDeleted");
            return Json(GeneralHelper.GetMessage<Customer>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteByCode([FromUri] string code)
        {
            var retVal = await new Repository<Customer>().DeleteByField("CustomerCode", code);
            return Json(GeneralHelper.GetMessage<Customer>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}