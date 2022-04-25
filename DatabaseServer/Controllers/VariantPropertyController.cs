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
    public class VariantPropertyController : ApiController
    {
        public IHttpActionResult Get()
        {
            var variantProperties = new Repository<VariantProperty>().Get().ToList();
            return Json(GeneralHelper.GetMessage<VariantProperty>(variantProperties, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{variantProperties.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var variantProperty = await new Repository<VariantProperty>().GetById(id);
            var retVal = (object)variantProperty ?? new { };
            return Json(GeneralHelper.GetMessage<VariantProperty>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public async Task<IHttpActionResult> GetByGroupId(int groupId)
        {
            return await Task.Run(() =>
            {
                var variantProperty = new Repository<VariantProperty>().GetByProperty("VariantGroupId", groupId);
                
                return Json(GeneralHelper.GetMessage<VariantProperty>(variantProperty, Messages.SUCCESS_GET,
                    GeneralHelper.StatusType.Success));
            });


        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(VariantProperty variantProperty)
        {
            var retVal = await new Repository<VariantProperty>().Add(variantProperty);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<VariantProperty> variantProperties)
        {
            var retVal = await new Repository<VariantProperty>().AddList(variantProperties);
            return Json(retVal);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(VariantProperty variantProperty)
        {
            var retVal = await new Repository<VariantProperty>().Update(variantProperty);
            return Json(GeneralHelper.GetMessage<VariantProperty>(new []{retVal}, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<VariantProperty>().Delete(id);
            return Json(GeneralHelper.GetMessage<VariantProperty>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}