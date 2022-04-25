using System;
using DAL;
using DatabaseServer.Filters;
using DatabaseServer.Helper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace DatabaseServer.Controllers
{
    [JwtAuthentication]
    public class ProductController : ApiController
    {
        public IHttpActionResult Get()
        {
            var products = new Repository<Product>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Product>(products, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{products.Count} Adet Kayıt Bulundu."));
        }
        public IHttpActionResult GetDetail()
        {
            var products = new Repository<VwProduct>().GetByProperty("IsDeleted", false).ToList();
            return Json(GeneralHelper.GetMessage<VwProduct>(products, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{products.Count} Adet Kayıt Bulundu."));
        }


        public IHttpActionResult GetDetail(int skip, int take)
        {

            var products = new Repository<VwProduct>()
                .GetByWhereExpression(Repository<VwProduct>.GetPropertyExpression("IsDeleted", false)).OrderBy(q=>q.ProductId).Skip(skip)
                .Take(take).ToList();
            return Json(GeneralHelper.GetMessage<VwProduct>(products, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{products.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var product = await new Repository<Product>().GetById(id);
            var retVal = (object)product ?? new { };
            return Json(GeneralHelper.GetMessage<Product>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }


        public async Task<IHttpActionResult> Get(int skip,int take)
        {
            var product = await  new Repository<Product>().GetBySkipAndTake(skip,take);
            var retVal = (object)product ?? new { };
            return Json(GeneralHelper.GetMessage<Product>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public async Task<IHttpActionResult> GetDetail(string property, string  value)
        {
            
            var products = new Repository<VwProduct>().
                GetByWhereExpression(
                Repository<VwProduct>.GetStringMethodsExpression(property, value, "StartsWith")).ToList();

            return Json(GeneralHelper.GetMessage<VwProduct>(products, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{products.Count} Adet Kayıt Bulundu."));
        }


        [HttpGet]
        public IHttpActionResult GetByBarcode(string barcode)
        {
            var product = new Repository<Product>().GetByProperty("Barcode", barcode);
            return Json(GeneralHelper.GetMessage<Product>(product, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, "1 Adet Kayıt Bulundu."));
        }

        [HttpGet]
        public IHttpActionResult GetDetailByBarcode(string barcode)
        {
            var product = new Repository<VwProduct>().GetByProperty("Barcode", barcode);
            return Json(GeneralHelper.GetMessage<VwProduct>(product, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, "1 Adet Kayıt Bulundu."));
        }

        [HttpGet]
        public IHttpActionResult GetByCode(string code)
        {
            var product = new Repository<Product>().GetByProperty("ProductCode", code);
            return Json(GeneralHelper.GetMessage<Product>(product, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpGet]
        public IHttpActionResult GetDetailByCode(string code)
        {
            var product = new Repository<VwProduct>().GetByProperty("ProductCode", code);
            return Json(GeneralHelper.GetMessage<VwProduct>(product, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpGet]
        public IHttpActionResult GetDetailByName(string name)
        {
            var product = new Repository<VwProduct>().GetByProperty("ProductName", name);
            return Json(GeneralHelper.GetMessage<VwProduct>(product, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(Product product)
        {
            var retVal = await new Repository<Product>().Add(product);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<Product> products)
        {
            var retVal = await new Repository<Product>().AddList(products);
            return Json(retVal);
        }


        [HttpPut]
        public async Task<IHttpActionResult> Update(Product product)
        {
            var retVal = await new Repository<Product>().Update(product);
            return Json(GeneralHelper.GetMessage<Product>(new []{retVal}, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateList([FromBody] List<Product> products)
        {
            var retVal = await new Repository<Product>().UpdateList(products);
            return Json(GeneralHelper.GetMessage<Product>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            //var retVal = await new Repository<Product>().Delete(id);
            //return Json(GeneralHelper.GetMessage<Product>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));

            var product = await new Repository<Product>().GetById(id);
            product.IsDeleted = true;
            var retVal = await new Repository<Product>().UpdateListByFields(
                new List<Product>()
                {
                    product
                }, "IsDeleted");
            return Json(GeneralHelper.GetMessage<Product>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteByCode([FromUri] string code)
        {
            var retVal = await new Repository<Product>().DeleteByField("ProductCode", code);
            return Json(GeneralHelper.GetMessage<Product>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}