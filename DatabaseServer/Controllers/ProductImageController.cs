using DAL;
using DatabaseServer.Filters;
using DatabaseServer.Helper;
using DatabaseServer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DatabaseServer.Controllers
{
    [JwtAuthentication]
    public class ProductImageController : ApiController
    {
        //public async Task<IHttpActionResult> Get(int id)
        //{
        //    var productImage = await new Repository<ProductImage>().GetById(id);
        //    var retVal = (object)productImage ?? new { };
        //    return Json(GeneralHelper.GetMessage<ProductImage>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        //}

        public IHttpActionResult GetByProductCode(string productCode, int lineNumber)
        {
            var productId = GetProductId(productCode);
            if (productId == 0) return null;
            var productImage = new Repository<ProductImage>().GetByProperty("ProductId", productId).FirstOrDefault(l => l.LineNumber == lineNumber);
            if (productImage == null) return null;
            var webImage = new WebImage(productImage, productCode);
            var retVal = (object)webImage;
            return Json(GeneralHelper.GetMessage<WebImage>(new[] { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        public IHttpActionResult GetDefaultByProductCode(string productCode)
        {
            var productId = GetProductId(productCode);
            if (productId == 0) return null;
            var images = new Repository<ProductImage>().GetByProperty("ProductId", productId);
            var productImage = images.FirstOrDefault(l => l.IsDefault)??images.FirstOrDefault();
            if (productImage == null) return null;
            var webImage = new WebImage(productImage, productCode);
            var retVal = (object)webImage;
            return Json(GeneralHelper.GetMessage<WebImage>(new[] { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        //public IHttpActionResult GetByProductId(int productId)
        //{
        //    var productImages = new Repository<ProductImage>().GetByProperty("ProductId", productId).OrderBy(l => l.LineNumber);
        //    return Json(GeneralHelper.GetMessage<ProductImage>(productImages, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        //}

        //public IHttpActionResult GetByProductId(int productId, int lineNumber)
        //{
        //    var productImage = new Repository<ProductImage>().GetByProperty("ProductId", productId).FirstOrDefault(l => l.LineNumber == lineNumber);
        //    var retVal = (object)productImage ?? new { };
        //    return Json(GeneralHelper.GetMessage<ProductImage>(new List<object> { retVal }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        //}

        public IHttpActionResult GetByProductCode(string productCode)
        {
            var productId = GetProductId(productCode);
            if (productId == 0) return null;
            var productImages = new Repository<ProductImage>().GetByProperty("ProductId", productId).OrderBy(l => l.LineNumber);
            var webImages = productImages.Select(l => new WebImage(l, productCode)).ToList();
            return Json(GeneralHelper.GetMessage<WebImage>(webImages, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(WebImage webImage)
        {
            var productId = GetProductId(webImage.ProductCode);
            if (productId == 0)
                return Json(new WebImage());
            var imagePath = ImageManager.CreateImage(webImage);
            if (imagePath == null)
                return Json(new WebImage());

            var piRepository = new Repository<ProductImage>();
            var productImages = piRepository.GetByProperty("ProductId", productId);

            if (webImage.LineNumber == 0)
            {
                var lastNumber = productImages.Any() ? productImages.Max(l => l.LineNumber) : (byte)0;
                webImage.LineNumber = ++lastNumber;
            }
            else if (productImages.Count(l => l.LineNumber == webImage.LineNumber) > 0)
            {
                var images = productImages.Where(l => l.LineNumber >= webImage.LineNumber);
                foreach (var image in images)
                {
                    image.LineNumber = ++image.LineNumber;
                    await piRepository.Update(image);
                }
            }

            var productImage = new ProductImage
            {
                ProductId = productId,
                ImagePath = imagePath,
                LineNumber = webImage.LineNumber,
                IsDefault = false
            };

            productImage = await piRepository.Add(productImage);
            webImage.ProductImageId = productImage.ProductImageId;
            webImage.ProductId = productImage.ProductId;
            //return Json(webImage);
            return Json(GeneralHelper.GetMessage<WebImage>(new[] { webImage }, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostList([FromBody] List<WebImage> webImages)
        {
            var retVal = new List<WebImage>();
            var piRepository = new Repository<ProductImage>();

            foreach (var webImage in webImages)
            {
                var productId = GetProductId(webImage.ProductCode);
                if (productId == 0) continue;
                var imagePath = ImageManager.CreateImage(webImage);
                if (imagePath == null) continue;
                var productImages = piRepository.GetByProperty("ProductId", productId);

                if (webImage.LineNumber == 0)
                {
                    var lastNumber = productImages.Any() ? productImages.Max(l => l.LineNumber) : (byte)0;
                    webImage.LineNumber = ++lastNumber;
                }
                else if (productImages.Count(l => l.LineNumber == webImage.LineNumber) > 0)
                {
                    var images = productImages.Where(l => l.LineNumber >= webImage.LineNumber);
                    foreach (var image in images)
                    {
                        image.LineNumber = ++image.LineNumber;
                        await piRepository.Update(image);
                    }
                }

                var productImage = new ProductImage
                {
                    ProductId = productId,
                    ImagePath = imagePath,
                    LineNumber = webImage.LineNumber,
                    IsDefault = false
                };
                productImage = await piRepository.Add(productImage);
                webImage.ProductImageId = productImage.ProductImageId;
                webImage.ProductId = productImage.ProductId;
                retVal.Add(webImage);
            }
            //return Json(retVal);
            return Json(GeneralHelper.GetMessage<WebImage>(retVal, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateDefault(string productCode, int imageId)
        {
            var productId = GetProductId(productCode);
            if (productId == 0) return null;
            var piRepository = new Repository<ProductImage>();
            var productImages = piRepository.GetByProperty("ProductId", productId);
            if (productImages.Count == 0 || productImages.Count(l => l.ProductImageId == imageId) == 0)
                return null;
            productImages.ForEach(l => l.IsDefault = l.ProductImageId == imageId);
            var retVal = await piRepository.UpdateList(productImages);
            return Json(GeneralHelper.GetMessage<WebImage>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success));
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateLineNumber(string productCode, int imageId, byte lineNumber)
        {
            var productId = GetProductId(productCode);
            if (productId == 0 || lineNumber == 0) return null;
            var piRepository = new Repository<ProductImage>();
            var productImages = piRepository.GetByProperty("ProductId", productId);
            if (productImages.Count == 0 || productImages.Count(l => l.ProductImageId == imageId) == 0)
                return null;

            if (productImages.Count(l => l.LineNumber == lineNumber) > 0)
            {
                var images = productImages.Where(l => l.LineNumber >= lineNumber);
                foreach (var image in images)
                {
                    image.LineNumber = ++image.LineNumber;
                    await piRepository.Update(image);
                }
            }

            var productImage = productImages.First(l => l.ProductImageId == imageId);
            productImage.LineNumber = lineNumber;
            var retVal = await piRepository.Update(productImage);
            return Json(GeneralHelper.GetMessage<WebImage>(new[] { retVal }, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success));
        }

        //[HttpPut]
        //public async Task<IHttpActionResult> UpdateList([FromBody] List<ProductImage> productImages)
        //{
        //    var retVal = await new Repository<ProductImage>().UpdateList(productImages);
        //    return Json(GeneralHelper.GetMessage<ProductImage>(null, Messages.SUCCESS_UPDATE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Güncellendi."));
        //}

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var retVal = await new Repository<ProductImage>().Delete(id);
            return Json(GeneralHelper.GetMessage<WebImage>(new[] { retVal }, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success));
        }

        //[HttpDelete]
        //public async Task<IHttpActionResult> DeleteByProductId([FromUri] string productId)
        //{
        //    var retVal = await new Repository<ProductImage>().DeleteByField("ProductId", productId);
        //    return Json(GeneralHelper.GetMessage<ProductImage>(null, Messages.SUCCESS_DELETE, GeneralHelper.StatusType.Success, $"{retVal} Adet Kayıt Silindi."));
        //}


        private static int GetProductId(string productCode)
        {
            return new Repository<Product>().GetByProperty("ProductCode", productCode).FirstOrDefault()?.ProductId ?? 0;
        }
    }
}