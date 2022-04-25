using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using SimpleWarehouseWindows.Helpers.Models;
using SimpleWarehouseWindows.Models;


namespace SimpleWarehouseWindows.Helpers
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
                new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("barcode", barcode) });
            if (productList.Count == 0)
                throw new Exception("Ürün Bulunamadı");
            return productList[0];
        }

        internal static async Task<string> GetToken(string userName, string password)
        {
            var postObject = new Dictionary<string, object>()
            {
                { "UserName",userName},
                { "Password",password},
                { "IpAddress",""}
            };
            var serverIp = System.Configuration.ConfigurationSettings.AppSettings["ServerIp"];
            //Helpers.RestSharpManager.Init("http://192.168.1.102:63803");
            Helpers.RestSharpManager.Init(serverIp);
            var token = await RestSharpManager.RestSharpPost<string>("api/token/post", postObject, "");
            return token;
        }


        private void GetServer(string method)
        {

        }

        //private string PostServer(string method, object postObject)
        //{

        //}
        public static async Task<User> GetUserByUserName(string userName)
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
                new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("documentCode", docNumber) });
        }

        public static async void DeleteDetailByDocNumberAndProductId(string docNumber, int productId)
        {
            await RestSharpManager.RestSharpDelete("api/productdetail/deleteByDocNumberAndProductId",
                 SettingsHelper.Token,
                 new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("documentCode", docNumber), new KeyValuePair<string, object>("productId", productId) });
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

        public static async Task<List<OrderStatus>> GetOrderStatusList()
        {
            return await RestSharpManager.RestSharpGet<OrderStatus>("api/orderstatus/get",
                SettingsHelper.Token);
        }

        public static async Task<OrderStatus> AddOrderStatus(OrderStatus orderStatus)
        {
            return await RestSharpManager.RestSharpPost<OrderStatus>("api/orderstatus/Post", orderStatus,
                SettingsHelper.Token);
        }

        public static async Task UpdateOrderStatus(OrderStatus orderStatus)
        {
            await RestSharpManager.RestSharpPut<int>("api/orderstatus/update", orderStatus,
                SettingsHelper.Token);
        }

        public static async Task DeleteOrderStatus(int orderStatusId)
        {
            await RestSharpManager.RestSharpDelete($"api/orderstatus/delete/{orderStatusId}", SettingsHelper.Token);
        }

        public static async Task<List<Unit>> GetUnitList()
        {
            return await RestSharpManager.RestSharpGet<Unit>("api/Unit/get",
                SettingsHelper.Token);
        }

        public static async Task<Unit> AddUnit(Unit unit)
        {
            return await RestSharpManager.RestSharpPost<Unit>("api/unit/Post", unit,
                SettingsHelper.Token);
        }

        public static async Task UpdateUnit(Unit unit)
        {
            await RestSharpManager.RestSharpPut<int>("api/unit/update", unit,
                SettingsHelper.Token);
        }

        public static async Task DeleteUnit(int unitId)
        {
            await RestSharpManager.RestSharpDelete($"api/unit/delete/{unitId}", SettingsHelper.Token);
        }

        public static async Task<List<VariantGroup>> GetVariantGroupList()
        {
            return await RestSharpManager.RestSharpGet<VariantGroup>("api/variantGroup/get",
                SettingsHelper.Token);
        }

        public static async Task<VariantGroup> AddVariantGroup(VariantGroup variantGroup)
        {

            return await RestSharpManager.RestSharpPost<VariantGroup>("api/variantGroup/Post", variantGroup,
                SettingsHelper.Token);
        }

        public static async Task UpdateVariantGroup(VariantGroup variantGroup)
        {
            await RestSharpManager.RestSharpPut<int>("api/variantGroup/update", variantGroup,
                SettingsHelper.Token);
        }

        public static async Task DeleteVariantGroup(int variantGroupId)
        {
            await RestSharpManager.RestSharpDelete($"api/variantgroup/delete/{variantGroupId}", SettingsHelper.Token);
        }

        public static async Task<List<VariantProperty>> GetVariantPropertyListByGroupId(int groupId)
        {
            return await RestSharpManager.RestSharpGet<VariantProperty>(
                $"api/VariantProperty/GetByGroupId/?groupId={groupId}",
                SettingsHelper.Token);
        }

        public static async Task<VariantProperty> AddVariantProperty(VariantProperty variantProperty)
        {
            return await RestSharpManager.RestSharpPost<VariantProperty>("api/variantProperty/Post", variantProperty,
                SettingsHelper.Token);
        }

        public static async Task UpdateVariantProperty(VariantProperty variantProperty)
        {
            //
            await RestSharpManager.RestSharpPut<int>("api/VariantProperty/update", variantProperty,
                SettingsHelper.Token);
        }

        public static async Task DeleteVariantProperty(int variantPropertyId)
        {
            await RestSharpManager.RestSharpDelete($"api/VariantProperty/delete/{variantPropertyId}", SettingsHelper.Token);
        }

        public static async Task<List<VwCustomer>> GetCustomerList()
        {
            return await RestSharpManager.RestSharpGet<VwCustomer>("api/customer/GetDetail",
                SettingsHelper.Token);
        }

        public static List<Country> GetCountryListSynchronous()
        {
            return RestSharpManager.RestSharpGetSencron<Country>("api/Country/get",
                SettingsHelper.Token);
        }

        public static async Task<List<Country>> GetCountryList()
        {
            return await RestSharpManager.RestSharpGet<Country>("api/Country/get",
                SettingsHelper.Token);
        }
        public static List<City> GetCityListSynchronous(int countryId)
        {
            return RestSharpManager.RestSharpGetSencron<City>($"api/city/GetByCountryId?countryId={countryId}",
                SettingsHelper.Token);
        }
        public static async Task<List<City>> GetCityList(int countryId)
        {
            return await RestSharpManager.RestSharpGet<City>($"api/city/GetByCountryId?countryId={countryId}",
                SettingsHelper.Token);
        }
        public static List<Town> GetTownListSynchronous(int cityId)
        {
            return RestSharpManager.RestSharpGetSencron<Town>($"api/town/GetByCityId?cityId={cityId}",
                SettingsHelper.Token);
        }
        public static async Task<List<Town>> GetTownList(int cityId)
        {
            return await RestSharpManager.RestSharpGet<Town>($"api/town/GetByCityId?cityId={cityId}",
                SettingsHelper.Token);
        }

        public static async Task<Customer> AddCustomer(Customer customer)
        {
            return await RestSharpManager.RestSharpPost<Customer>("api/customer/Post", customer,
                SettingsHelper.Token);
        }

        public static async Task UpdateCustomer(Customer customer)
        {
            await RestSharpManager.RestSharpPut<int>("api/Customer/update", customer,
                SettingsHelper.Token);
        }

        public static async Task DeleteCustomer(int customerId)
        {
            await RestSharpManager.RestSharpDelete($"api/Customer/delete/{customerId}", SettingsHelper.Token);
        }

        public static async Task<List<VwProduct>> GetProductList()
        {
            return await RestSharpManager.RestSharpGet<VwProduct>("api/product/GetDetail",
                SettingsHelper.Token);
        }

        public static async Task<List<Currency>> GetCurrencyList()
        {
            return await RestSharpManager.RestSharpGet<Currency>("api/Currency/get",
                SettingsHelper.Token);
        }
        public static List<Currency> GetCurrencyListSencron()
        {
            return RestSharpManager.RestSharpGetSencron<Currency>("api/Currency/get", SettingsHelper.Token);
        }
        public static async Task<Product> AddProduct(Product product)
        {
            return await RestSharpManager.RestSharpPost<Product>("api/product/Post", product,
                SettingsHelper.Token);
        }

        public static async Task ProductUpdate(Product product)
        {
            await RestSharpManager.RestSharpPut<int>("api/Product/update", product,
                SettingsHelper.Token);
        }

        public static async Task DeleteProduct(int productId)
        {
            await RestSharpManager.RestSharpDelete($"api/product/delete/{productId}", SettingsHelper.Token);
        }

        public static async Task<List<Warehouse>> GetWarehouseList()
        {
            return await RestSharpManager.RestSharpGet<Warehouse>("api/warehouse/get", SettingsHelper.Token);
        }

        public static async Task<List<WebImage>> GetProductImage(string productCode)
        {
            return await RestSharpManager.RestSharpGet<WebImage>($"api/productImage/GetByProductCode/?productCode={productCode}", SettingsHelper.Token);
        }

        public static async Task<List<WebImage>> GetDefaultImageByProductCode(string productCode)
        {
            return await RestSharpManager.RestSharpGet<WebImage>($"api/productImage/GetDefaultByProductCode/?productCode={productCode}", SettingsHelper.Token);
        }

        public static async Task ChangeApprovingForDetail(int productDetailId, bool approve)
        {
            await RestSharpManager.RestSharpPut<int>($"api/productDetail/UpdateApprove?detailId={productDetailId}&approve={approve}", null, SettingsHelper.Token);
        }

        public static async Task<WebImage> UploadImage(WebImage webImage)
        {
            return await RestSharpManager.RestSharpPost<WebImage>("api/productImage/Post", webImage,
                SettingsHelper.Token);
        }

        public static async Task DeleteImage(WebImage webImage)
        {
            await RestSharpManager.RestSharpDelete($"api/productImage/delete/{webImage.ProductImageId}", SettingsHelper.Token);
        }

        public static async Task SetDefaultImage(WebImage image)
        {
            await RestSharpManager.RestSharpPut<int>($"api/productImage/UpdateDefault?productCode={image.ProductCode}&imageId={image.ProductImageId}", null, SettingsHelper.Token);
        }

        public static async Task<Customer> GetCustomer(int id)
        {
            return (await RestSharpManager.RestSharpGet<Customer>($"api/customer/Get/{id}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static List<PriceListGroup> GetPriceListGroupSynchronous()
        {
            return RestSharpManager.RestSharpGetSencron<PriceListGroup>($"api/PriceListGroup/Get", SettingsHelper.Token);
        }
        /// <summary>
        /// En Son Cari Kodu Döndürür.
        /// </summary>
        /// <param name="prefix">Cari Kodun Başladığı Ön Ek</param>
        /// <returns></returns>
        public static async Task<string> GetCurrentCustomerCode(string prefix)
        {
            return (await RestSharpManager.RestSharpGet<string>($"api/prefix/GetPrefix/?prefix={prefix}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task<List<VwCustomerDetail>> GetCustomerDetailList()
        {
            return RestSharpManager.RestSharpGetSencron<VwCustomerDetail>($"api/CustomerDetail/Get", SettingsHelper.Token);
        }

        public static async Task<List<VwCustomerDetail>> GetCustomerDetailListByCustomerId(int customerId)
        {
            return RestSharpManager.RestSharpGetSencron<VwCustomerDetail>($"api/CustomerDetail/GetCustomerDetailListByCustomerId?customerId={customerId}", SettingsHelper.Token);
        }

        public static List<CustomerDetailType> GetCustomerDetailsSynchronous()
        {
            return RestSharpManager.RestSharpGetSencron<CustomerDetailType>($"api/CustomerDetailType/Get", SettingsHelper.Token);
        }

        public static async Task<CustomerDetail> AddCustomerDetail(CustomerDetail detail)
        {
            return await RestSharpManager.RestSharpPost<CustomerDetail>("api/CustomerDetail/Post", detail,
                SettingsHelper.Token);
        }

        public static async Task UpdateCustomerDetail(CustomerDetail detail)
        {
            await RestSharpManager.RestSharpPut<int>("api/CustomerDetail/update", detail,
                SettingsHelper.Token);
        }

        public static async Task<CustomerDetail> GetCustomerDetail(int detailId)
        {
            return (await RestSharpManager.RestSharpGet<CustomerDetail>($"api/CustomerDetail/Get/{detailId}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task DeleteCustomerDetail(int customerDetailId)
        {
            await RestSharpManager.RestSharpDelete($"api/CustomerDetail/delete/{customerDetailId}", SettingsHelper.Token);
        }

        public static async Task<Supplier> GetSupplier(int id)
        {
            return (await RestSharpManager.RestSharpGet<Supplier>($"api/Supplier/Get/{id}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task<object> GetSupplierDetailListByCustomerId(int id)
        {
            //return RestSharpManager.RestSharpGetSencron<VwCustomerDetail>($"api/CustomerDetail/GetCustomerDetailListByCustomerId?customerId={customerId}", SettingsHelper.Token);
            return new List<object>();
        }

        public static async Task UpdateSupplier(Supplier supplier)
        {
            await RestSharpManager.RestSharpPut<int>("api/Supplier/update", supplier,
                SettingsHelper.Token);
        }

        public static async Task<Supplier> AddSupplier(Supplier supplier)
        {
            return await RestSharpManager.RestSharpPost<Supplier>("api/Supplier/Post", supplier,
                SettingsHelper.Token);
        }

        public static async Task<List<VwSupplier>> GetSupplierList()
        {
            return await RestSharpManager.RestSharpGet<VwSupplier>("api/Supplier/GetDetail",
                SettingsHelper.Token);
        }

        public static async Task DeleteSupplier(int supplierId)
        {
            await RestSharpManager.RestSharpDelete($"api/Supplier/delete/{supplierId}", SettingsHelper.Token);
        }

        public static async Task<List<VwSupplierDetail>> GetSupplierDetailList()
        {
            return await RestSharpManager.RestSharpGet<VwSupplierDetail>($"api/SupplierDetail/Get", SettingsHelper.Token);
        }

        public static async Task<SupplierDetail> GetSupplierDetail(int detailId)
        {
            return (await RestSharpManager.RestSharpGet<SupplierDetail>($"api/SupplierDetail/Get/{detailId}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task<SupplierDetail> AddSupplierDetail(SupplierDetail detail)
        {
            return await RestSharpManager.RestSharpPost<SupplierDetail>("api/SupplierDetail/Post", detail,
                SettingsHelper.Token);
        }

        public static async Task UpdateSupplierDetail(SupplierDetail detail)
        {
            await RestSharpManager.RestSharpPut<int>("api/SupplierDetail/update", detail,
                SettingsHelper.Token);
        }

        public static async Task DeleteSupplierDetail(int detailSupplierDetailId)
        {
            await RestSharpManager.RestSharpDelete($"api/SupplierDetail/delete/{detailSupplierDetailId}", SettingsHelper.Token);
        }


        public static async Task<List<ProductVariant>> GetProductVariants(int productId)
        {
            return RestSharpManager.RestSharpGetSencron<ProductVariant>($"api/Variant/GetVariantViewByProductId?productId={productId}", SettingsHelper.Token);
        }

        public static async Task UpdateVariant(Variant variant)
        {
            await RestSharpManager.RestSharpPut<int>("api/variant/update", variant,
                SettingsHelper.Token);
        }

        public static async Task<Variant> AddVariant(Variant variant)
        {
            return await RestSharpManager.RestSharpPost<Variant>("api/variant/Post", variant,
                SettingsHelper.Token);
        }

        public static async Task<List<ProductVariantWithGroupName>> GetProductVariantsWithGroup(int productId)
        {
            return RestSharpManager.RestSharpGetSencron<ProductVariantWithGroupName>($"api/Variant/GetProductVariantWithGroupNameByProductId?productId={productId}", SettingsHelper.Token);
        }

        public static async Task DeleteVariant(int variantId)
        {
            await RestSharpManager.RestSharpDelete($"api/Variant/delete/{variantId}", SettingsHelper.Token);
        }

        public static async Task<List<PriceListGroup>> GetPriceListGroups()
        {
            return await RestSharpManager.RestSharpGet<PriceListGroup>($"api/PriceListGroup/Get", SettingsHelper.Token);
        }

        public static async Task<int> SetPriceList(List<ProductPriceList> prices)
        {
            return await RestSharpManager.RestSharpPut<int>("api/ProductPriceList/SetProductPriceList", prices,
                SettingsHelper.Token);
        }

        public static async Task<List<ProductPriceList>> GetProductPrices(int id)
        {
            return await RestSharpManager.RestSharpGet<ProductPriceList>($"api/ProductPriceList/GetByProductId?productId={id}", SettingsHelper.Token);
        }

        public static async Task<List<VwProductDetails>> GetProductDetailByProductCode(int id)
        {
            return await RestSharpManager.RestSharpGet<VwProductDetails>($"api/ProductDetail/GetByProductId?productId={id}", SettingsHelper.Token);
        }

        public static async Task<List<VwProductDetails>> GetProductDetails()
        {
            return await RestSharpManager.RestSharpGet<VwProductDetails>($"api/ProductDetail/GetView", SettingsHelper.Token);
        }

        public static async Task<List<VwOrder>> GetOrderList()
        {
            return await RestSharpManager.RestSharpGet<VwOrder>($"api/Order/GetView", SettingsHelper.Token);
        }

        public static async Task<List<OrderType>> GetOrderType()
        {
            return await RestSharpManager.RestSharpGet<OrderType>($"api/OrderType/Get", SettingsHelper.Token);
        }

        public static async Task<Customer> GetCustomerByCode(string customerCode)
        {
            return (await RestSharpManager.RestSharpGet<Customer>($"api/customer/GetByCode/?code={customerCode}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static List<ProductPriceList> GetPriceByProductIdAndPriceListGroupId(int productId, int? priceListGroupId)
        {
            return RestSharpManager.RestSharpGetSencron<ProductPriceList>(
                $"api/ProductPriceList/GetPriceByProductIdAndPriceListGroupId?productId={productId}&priceListGroupId={priceListGroupId}",
                SettingsHelper.Token);
        }

        public static async Task<Order> AddOrder(FullOrder order)
        {
            return await RestSharpManager.RestSharpPost<Order>("api/order/PostFull", order,
                SettingsHelper.Token);
        }

        public static async Task<int> UpdateOrder(FullOrder order)
        {
            return await RestSharpManager.RestSharpPut<int>("api/order/UpdateOrder", order,
                SettingsHelper.Token);
        }

        public static async Task<FullOrder> GetOrder(int id)
        {
            return (await RestSharpManager.RestSharpGet<FullOrder>($"api/order/GetFullOrder/{id}", SettingsHelper.Token)).FirstOrDefault();
        }

        public static async Task DeleteOrder(int orderId)
        {
            await RestSharpManager.RestSharpDelete($"api/order/delete/{orderId}", SettingsHelper.Token);
        }
    }
}