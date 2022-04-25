using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using impleWarehouseMobil.Models;
using SimpleWarehouseMobil.Models;
using SimpleWarehouseXamarin.Helper;

namespace SimpleWarehouseMobil.Helpers
{
    public class ApiHelper
    {


        public static async Task<Product> GetProductByCode(string productCode)
        {
            var productList = await RestSharpManager.RestSharpGet<Product>("api/product/GetByCode", SettingsHelper.Token,
                new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("code", productCode) });
            if (productList.Count == 0)
                throw new Exception("Ürün Bulunamadı");
            return productList[0];
        }
        public static async Task<Product> GetProductByBarcode(string barcode)
        {
            var productList = await RestSharpManager.RestSharpGet<Product>("api/product/GetByBarcode", SettingsHelper.Token,
                new List<KeyValuePair<string, object>>() {new KeyValuePair<string, object>("barcode", barcode)});
            if(productList.Count==0)
                throw new Exception("Ürün Bulunamadı");
            return productList[0];
        }

        internal static async Task<string> GetToken(string userName, string password)
        {
            var postObject=new Dictionary<string, object>()
            {
                { "UserName",userName},
                { "Password",password},
                { "IpAddress",""}
            };

     
            Helpers.RestSharpManager.Init("http://localhost:63802");
            var token= await RestSharpManager.RestSharpPost<string>("api/token/post",postObject,"");
            return token;
        }


        private void GetServer(string method)
        {

        }

        //private string PostServer(string method, object postObject)
        //{
            
        //}
        public static async Task<User> getUserByUserName(string userName)
        {
            var userList = await RestSharpManager.RestSharpGet<User>("api/user/GetByUserName", SettingsHelper.Token,
                new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("userName", userName) });
            if (userList.Count == 0)
                throw new Exception("Kullanıcı Bulunamadı");
            return userList[0];
        }

        public static async Task<ProductDetail> AddProductDetail(ProductDetail productDetail)
        {
            return await RestSharpManager.RestSharpPost<ProductDetail>("api/productDetail/Post", productDetail,
                SettingsHelper.Token);
        }

        public static async Task<List<ProductDetail>> GetProductByDocumentNumber(string docNumber)
        {
            return await RestSharpManager.RestSharpGet<ProductDetail>("api/productdetail/GetByDocumentCode",
                SettingsHelper.Token,
                new List<KeyValuePair<string, object>>() {new KeyValuePair<string, object>("documentCode", docNumber)});
        }

        public static async void DeleteDetailByDocNumberAndProductId(string docNumber,  int productId)
        {
           await RestSharpManager.RestSharpDelete("api/productdetail/deleteByDocNumberAndProductId",
                SettingsHelper.Token,
                new List<KeyValuePair<string, object>>() {new KeyValuePair<string, object>("documentCode", docNumber),new KeyValuePair<string, object>("productId",productId)});
        }

        public static async Task DeleteDetail(int detailId)
        {
            await RestSharpManager.RestSharpDelete($"api/productdetail/delete/{detailId}", SettingsHelper.Token);
        }

        public static async Task<Product> GetProductById(int productId)
        {
            var productList = await RestSharpManager.RestSharpGet<Product>($"api/product/get/{productId}", SettingsHelper.Token);
            if (productList.Count == 0)
                throw new Exception("Ürün Bulunamadı");
            return productList[0];
        }

        public static async Task<int> ApproveDetails(List<int> detailIdList)
        {
            return await RestSharpManager.RestSharpPut<int>("api/productDetail/ApproveProductDetails", detailIdList,
                SettingsHelper.Token);
        }

        public static async Task<List<VwProduct>> GetProductList()
        {
            return await RestSharpManager.RestSharpGet<VwProduct>("api/product/GetDetail",
                SettingsHelper.Token);
        }
        public static async Task<List<VwProduct>> GetProductListBySkipAndTake(int skip,int take)
        {
            return await RestSharpManager.RestSharpGet<VwProduct>($"api/product/GetDetail?skip={skip}&take={take}",
                SettingsHelper.Token);
        }

        public static async Task<List<VwProduct>> GetProductWithLike(string property, string value)
        {
            return await RestSharpManager.RestSharpGet<VwProduct>($"api/product/GetDetail?property={property}&value={value}",
                SettingsHelper.Token);
        }

        public static async Task<List<Dictionary<string, object>>> GetProductImage(string productCode)
        {
            return await RestSharpManager.RestSharpGet<Dictionary<string, object>>(
                $"api/productimage/GetDefaultByProductCode?productCode={productCode}",
                SettingsHelper.Token);
        }

        public static async Task<List<VwProductPriceList>> GetProductPriceList(int productId)
        {
            return await RestSharpManager.RestSharpGet<VwProductPriceList>($"api/ProductPriceList/GetDetailByProductId?productId={productId}", SettingsHelper.Token);
        }    
        
        public static async Task<List<VwProductStockInWarehouse>> GetProductStockInWarehouse(int productId)
        {
            return await RestSharpManager.RestSharpGet<VwProductStockInWarehouse>($"api/ProductDetail/GetStockInWarehouseByProductId?productId={productId}", SettingsHelper.Token);
        }

        public static async Task<List<VwOrder>> GetOrdersLast100()
        {
            return await RestSharpManager.RestSharpGet<VwOrder>($"api/Order/GetView?productId=?skip={0}&take={100}", SettingsHelper.Token);
        }

        public static async Task<List<VwOrderDetails>> GetOrderDetailsView(int orderId)
        {
            return await RestSharpManager.RestSharpGet<VwOrderDetails>($"api/OrderDetail/GetViewByOrderId?orderId={orderId}", SettingsHelper.Token);
        }

        public static async Task<string> GetCurrentOrderCode(string prefix)
        {
            return (await RestSharpManager.RestSharpGet<string>($"api/prefix/GetPrefix/?prefix={prefix}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task<List<Currency>> GetCurrencyList()
        {
            return await RestSharpManager.RestSharpGet<Currency>($"api/Currency/Get", SettingsHelper.Token);
        }

        public static async Task<List<Unit>> GetUnitList()
        {
            return await RestSharpManager.RestSharpGet<Unit>($"api/Unit/Get", SettingsHelper.Token);
        }

        public static async Task<List<Warehouse>> GetWarehouseList()
        {
            return await RestSharpManager.RestSharpGet<Warehouse>($"api/Warehouse/Get", SettingsHelper.Token);
        }

        public static async Task<VwProduct> GetProductViewByBarcode(string barcode)
        {
            return (await RestSharpManager.RestSharpGet<VwProduct>($"api/Product/GetDetailByBarcode?barcode={barcode}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task<VwProduct> GetProductViewByCode(string code)
        {
            return (await RestSharpManager.RestSharpGet<VwProduct>($"api/Product/GetDetailByCode?code={code}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task<VwProduct> GetProductViewByName(string name)
        {
            return (await RestSharpManager.RestSharpGet<VwProduct>($"api/Product/GetDetailByName?name={name}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task<ProductVariant> GetSubproductViewByBarcodes(string barcode)
        {
            return (await RestSharpManager.RestSharpGet<ProductVariant>($"api/Variant/GetVariantViewByBarcode?barcode={barcode}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task<VwProduct> GetProductViewById(int? productId)
        {
            return (await RestSharpManager.RestSharpGet<VwProduct>($"api/Product/Get?id={productId??0}", SettingsHelper.Token)).FirstOrDefault();

        }

        public static async Task<List<ProductVariant>> GetVProductVariantList(int productId)
        {
            return await RestSharpManager.RestSharpGet<ProductVariant>($"api/Variant/GetVariantViewByProductId?productId={productId}", SettingsHelper.Token);

        }

        public static async Task<List<VwProductPriceList>> GerProductPrice(int productId, int groupId)
        {
            //
            return await RestSharpManager.RestSharpGet<VwProductPriceList>($"api/ProductPriceList/GetPriceByProductIdAndGroupType?productId={productId}&groupType={groupId}", SettingsHelper.Token);

        }

        public static async Task<ProductVariant> GetVariant(int? variantId)
        {
            return (await RestSharpManager.RestSharpGet<ProductVariant>($"api/Variant/GetVariantView?id={variantId}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static ProductVariant GetVariantSync(int? variantId)
        {
            return Task.Run(async () =>
            {
                return (await RestSharpManager.RestSharpGet<ProductVariant>(
                    $"api/Variant/GetVariantView?id={variantId}", SettingsHelper.Token)).FirstOrDefault();
            }).GetAwaiter().GetResult();

        }

        public static async Task<IEnumerable> GetCustomerList()
        {
            return await RestSharpManager.RestSharpGet<VwCustomer>($"api/Customer/GetDetail?skip={0}&take={100}", SettingsHelper.Token);
        }

        public static async Task<IEnumerable> GetCustomerStartWith(string code)
        {
            return await RestSharpManager.RestSharpGet<VwCustomer>($"api/Customer/GetByCodeStartWith?code={code}", SettingsHelper.Token);
        }

        public static async Task<Order> AddOrder(FullOrder order)
        {
            return await RestSharpManager.RestSharpPost<Order>("api/order/PostFull", order,
                SettingsHelper.Token);
        }

        public static async Task<IEnumerable> GetOrderCodeStartWith(string orderCode)
        {
            return await RestSharpManager.RestSharpGet<VwOrder>($"api/Order/GetViewOrderCodeStartWith?orderCode={orderCode}", SettingsHelper.Token);
        }
    }
}