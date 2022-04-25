using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SimpleWarehouseMobil.Models;

namespace SimpleWarehouseMobil.Helpers
{
    public class ApiHelper
    {

        static List<string> productNames=new List<string>()
        {
            "Ürün 1","Sakız","Peskövit","Don Lastiği","Araba","Telefon"
        };

        static List<string> barcodes = new List<string>()
        {
            "11111111111","2222222222","333333333333","444444444444","55555555","6666666666666"
        };
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

            Helpers.RestSharpManager.Init("http://85.105.170.95:8081");
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
    }
}