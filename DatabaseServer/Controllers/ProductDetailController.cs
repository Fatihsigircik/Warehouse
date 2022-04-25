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
    public class ProductDetailController : ApiController
    {
        public IHttpActionResult Get()
        {
            var productDetails = new Repository<ProductDetail>().Get().ToList();
            return Json(GeneralHelper.GetMessage<ProductDetail>(productDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{productDetails.Count} Adet Kayıt Bulundu."));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var productDetail = await new Repository<ProductDetail>().GetById(id);
            var retVal = (object)productDetail ?? new { };
            return Json(GeneralHelper.GetMessage<ProductDetail>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpGet]
        public IHttpActionResult GetByDocumentCode(string documentCode)
        {
            var productDetails = new Repository<ProductDetail>().GetByProperty("DocumentCode", documentCode);
            return Json(GeneralHelper.GetMessage<ProductDetail>(productDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }
        [HttpGet]
        public IHttpActionResult GetByProductId(int productId)
        {
            var productDetails = new Repository<VwProductDetails>().GetByProperty("ProductId", productId);
            return Json(GeneralHelper.GetMessage<VwProductDetails>(productDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetStockInWarehouseByProductId(int productId)
        {
            var productDetails = new Repository<VwProductStockInWarehouse>().GetByProperty("ProductId", productId);
            
            return Json(GeneralHelper.GetMessage<VwProductStockInWarehouse>(productDetails, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }


        public async Task<IHttpActionResult> GetView()
        {
            var productDetail = new Repository<VwProductDetails>().Get().ToList();
            //var retVal = (object)productDetail ?? new { };
            return Json(GeneralHelper.GetMessage<VwProductDetails>(productDetail, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(ProductDetail productDetail)
        {
            var retVal = await new Repository<ProductDetail>().Add(productDetail);
            return Json(retVal);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<ProductDetail> productDetails)
        {
            var retVal = await new Repository<ProductDetail>().AddList(productDetails);
            return Json(retVal);
        }

        [HttpPut]
        public IHttpActionResult Update(ProductDetail productDetail)
        {
            var retVal = new Repository<ProductDetail>().Update(productDetail);
            return Json(GeneralHelper.GetMessage<ProductDetail>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateList([FromBody] List<ProductDetail> productDetails)
        {
            var retVal = await new Repository<ProductDetail>().UpdateList(productDetails);
            return Json(GeneralHelper.GetMessage<ProductDetail>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }
        [HttpPut]
        public async Task<IHttpActionResult> ApproveProductDetails([FromBody] List<int> productIds)
        {
            var productDetails = new List<ProductDetail>();
            foreach (var productId in productIds)
            {
                var newProductDetail = new ProductDetail() { ProductDetailId = productId, IsApproved = true };
                productDetails.Add(newProductDetail);
            }
            var retVal = await new Repository<ProductDetail>().UpdateListByFields(productDetails, "IsApproved");
            return Json(GeneralHelper.GetMessage<ProductDetail>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateApprove(int detailId, bool approve)
        {
            var newProductDetail = new ProductDetail() { ProductDetailId = detailId, IsApproved = approve };


            var retVal = await new Repository<ProductDetail>().UpdateListByFields(new List<ProductDetail>() { newProductDetail }, "IsApproved");
            return Json(GeneralHelper.GetMessage<ProductDetail>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        }
        [HttpDelete]
        public IHttpActionResult DeleteByDocNumberAndProductId(string documentCode, int productId)
        {
            var productDetails = new Repository<ProductDetail>().DeleteByMultiField(new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("DocumentCode",documentCode),
                new KeyValuePair<string, object>("ProductId",productId)
            });
            return Json(GeneralHelper.GetMessage<ProductDetail>(new ProductDetail[] { }, Messages.SUCCESS_GET,
                GeneralHelper.StatusType.Success, $"{productDetails} Adet Kayıt Silindi..."));
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<ProductDetail>().Delete(id);
            return Json(GeneralHelper.GetMessage<ProductDetail>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        }
    }
}