using DAL;

namespace DatabaseServer.Models
{
    public class WebImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Base64String { get; set; }
        public byte LineNumber { get; set; }
        public bool IsDefault { get; set; }

        public WebImage()
        {
        }

        public WebImage(ProductImage productImage, string productCode = null)
        {
            ProductImageId = productImage.ProductImageId;
            ProductId = productImage.ProductId;
            ProductCode = productCode;
            Base64String = ImageManager.GetImage(productImage.ImagePath);
            LineNumber = productImage.LineNumber;
            IsDefault = productImage.IsDefault;
        }
    }
}