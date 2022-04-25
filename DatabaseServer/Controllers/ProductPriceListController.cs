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
    public class ProductPriceListController : ApiController
    {
        public IHttpActionResult Get()
        {
            var productPriceLists = new Repository<ProductPriceList>().Get().ToList();
            return Json(GeneralHelper.GetMessage<ProductPriceList>(productPriceLists, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{productPriceLists.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var productPriceList = await new Repository<ProductPriceList>().GetById(id);
            var retVal = (object)productPriceList ?? new { };
            return Json(GeneralHelper.GetMessage<ProductPriceList>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
      public  IHttpActionResult GetPriceByProductIdAndPriceListGroupId(int productId,int priceListGroupId)
      {
          var productPriceList = new Repository<ProductPriceList>().GetByProperty("ProductId", productId);
          var productPrice = productPriceList.FirstOrDefault(q => q.PriceListGroupId == priceListGroupId) ??
                             productPriceList.FirstOrDefault(q => q.IsDefaultPrice);
            var retVal = (object)productPrice ?? new { };
            return Json(GeneralHelper.GetMessage<ProductPriceList>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

      public IHttpActionResult GetPriceByProductIdAndGroupType(int productId, int groupType)
      {
          var productPriceList = new Repository<VwProductPriceList>().GetByProperty("ProductId", productId);
          var productPrice = productPriceList.FirstOrDefault(q => q.GroupType == groupType) ??
                             productPriceList.FirstOrDefault(q => q.IsDefaultPrice);
          var retVal = (object)productPrice ?? new { };
          return Json(GeneralHelper.GetMessage<VwProductPriceList>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
      }

        [HttpGet]
        public IHttpActionResult GetByProductId(int productId)
        {
            var productPriceLists = new Repository<ProductPriceList>().GetByProperty("ProductId", productId);
            return Json(GeneralHelper.GetMessage<ProductPriceList>(productPriceLists, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpGet]
        public IHttpActionResult GetDetailByProductId(int productId)
        {
            var productPriceLists = new Repository<VwProductPriceList>().GetByProperty("ProductId", productId);
            return Json(GeneralHelper.GetMessage<VwProductPriceList>(productPriceLists, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }


        [HttpPut]
        public async Task<IHttpActionResult> SetProductPriceList(List<ProductPriceList> priceLists)
        {
            var retVal = 0;
            var repository = new Repository<ProductPriceList>();
            foreach (ProductPriceList list in priceLists)
            {
               await repository.DeleteByMultiField(new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("ProductId", list.ProductId),
                    new KeyValuePair<string, object>("PriceListGroupId", list.PriceListGroupId),
                });

               await repository.Add(list);
               retVal++;
            }

            return Json(GeneralHelper.GetMessage<ProductPriceList>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

    }
}
