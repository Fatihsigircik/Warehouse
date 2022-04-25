namespace SimpleWarehouseWcfService.Models
{
    public class WebImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Base64String { get; set; }
        public byte LineNumber { get; set; }
        public bool IsDefault { get; set; }
    }
}