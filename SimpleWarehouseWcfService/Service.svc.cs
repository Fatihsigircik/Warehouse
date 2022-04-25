using SimpleWarehouseWcfService.Helpers;
using SimpleWarehouseWcfService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleWarehouseWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public string GetData(int value)
        {
            return $"You entered: {value}";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException(nameof(composite));
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }



        public async Task<List<Product>> GetProducts()
        {
            return await RestHelper.Get<Product>("api/product/get");
        }

        //public async Task<Product> AddProduct(Product product)
        //{
        //    return await RestHelper.Post<Product>("api/product/post", product);
        //}


        //public async Task<bool> DeleteProduct(int id)
        //{
        //    return await RestHelper.Delete($"api/product/delete/{id}");
        //}





        public async Task<List<WebImage>> GetImagesByProductCode(string productCode)
        {
            return await RestHelper.Get<WebImage>("api/productImage/getByProductCode",
                new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("productCode", productCode) });
        }

        public async Task<List<WebImage>> GetImageByLineNumber(string productCode, int lineNumber)
        {
            return await RestHelper.Get<WebImage>("api/productImage/getByProductCode",
                new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("productCode", productCode), new KeyValuePair<string, object>("lineNumber", lineNumber) });
        }

        public async Task<List<WebImage>> GetDefaultImage(string productCode)
        {
            return await RestHelper.Get<WebImage>("api/productImage/getDefaultByProductCode",
                new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("productCode", productCode) });
        }

        public async Task<WebImage> AddImage(WebImage webImage)
        {
            return await RestHelper.Post<WebImage>("api/productImage/post", webImage);
        }

        public async Task<List<WebImage>> AddImages(List<WebImage> webImages)
        {
            /* webImages = new List<WebImage>
            {
                new WebImage
                {
                    ProductCode = "code4",
                    Base64String = "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"
                },
                new WebImage
                {
                    ProductCode = "code4",
                    Base64String = "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"
                }
            };
            */
            return await RestHelper.PostList<WebImage>("api/productImage/postList", webImages);
        }

        public async Task<bool> DeleteImage(int imageId)
        {
            return await RestHelper.Delete($"api/productImage/delete/{imageId}");
        }







        //public async Task<List<Order>> GetOrders()
        //{
        //    return await RestHelper.Get<Order>("api/order/get");
        //}
    }
}