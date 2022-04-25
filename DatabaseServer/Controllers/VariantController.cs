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
    public class VariantController : ApiController
    {
        public IHttpActionResult Get()
        {
            var variants = new Repository<Variant>().Get().ToList();
            return Json(GeneralHelper.GetMessage<Variant>(variants, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{variants.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var variant = await new Repository<Variant>().GetById(id);
            var retVal = (object)variant ?? new { };
            return Json(GeneralHelper.GetMessage<Variant>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetVariantView(int id)
        {
            var variant =  new Repository<ProductVariant>().GetByProperty("VariantId",id);
           
            return Json(GeneralHelper.GetMessage<ProductVariant>(variant, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetByProductId(int productId)
        {
            var variants = new Repository<Variant>().GetByProperty("ProductId", productId);
            return Json(GeneralHelper.GetMessage<Variant>(variants, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetVariantViewByProductId(int productId)
        {
            var variants = new Repository<ProductVariant>().GetByProperty("ProductId", productId);
            return Json(GeneralHelper.GetMessage<ProductVariant>(variants, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }  
        
        public IHttpActionResult GetProductVariantWithGroupNameByProductId(int productId)
        {
            var variants = new Repository<ProductVariantWithGroupName>().GetByProperty("ProductId", productId);
            return Json(GeneralHelper.GetMessage<ProductVariantWithGroupName>(variants, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        public IHttpActionResult GetByBarcode(string barcode)
        {
            var variants = new Repository<Variant>().GetByProperty("Barcode", barcode);
            return Json(GeneralHelper.GetMessage<Variant>(variants, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetVariantViewByBarcode(string barcode)
        {
            var variants = new Repository<ProductVariant>().GetByProperty("Barcode", barcode);
            return Json(GeneralHelper.GetMessage<ProductVariant>(variants, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(Variant variant)
        {
            var retVal = await new Repository<Variant>().Add(variant);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<Variant> variants)
        {
            var retVal = await new Repository<Variant>().AddList(variants);
            return Json(retVal);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(Variant variant)
        {
            var retVal = await new Repository<Variant>().Update(variant);
            return Json(GeneralHelper.GetMessage<Variant>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateList([FromBody] List<Variant> variants)
        {
            var retVal = await new Repository<Variant>().UpdateList(variants);
            return Json(GeneralHelper.GetMessage<Variant>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<Variant>().Delete(id);
            return Json(GeneralHelper.GetMessage<Variant>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}