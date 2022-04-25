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
    public class VariantGroupController : ApiController
    {
        public IHttpActionResult Get()
        {
            var variantGroups = new Repository<VariantGroup>().Get().ToList();
            return Json(GeneralHelper.GetMessage<VariantGroup>(variantGroups, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{variantGroups.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var variantGroup = await new Repository<VariantGroup>().GetById(id);
            var retVal = (object)variantGroup ?? new { };
            return Json(GeneralHelper.GetMessage<VariantGroup>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(VariantGroup variantGroup)
        {
            var retVal = await new Repository<VariantGroup>().Add(variantGroup);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<VariantGroup> variantGroups)
        {
            var retVal = await new Repository<VariantGroup>().AddList(variantGroups);
            return Json(retVal);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(VariantGroup variantGroup)
        {
            var retVal = await new Repository<VariantGroup>().Update(variantGroup);
            return Json(GeneralHelper.GetMessage<VariantGroup>(new []{retVal}, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<VariantGroup>().Delete(id);
            return Json(GeneralHelper.GetMessage<VariantGroup>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}