using SimpleWarehouseWcfService.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace SimpleWarehouseWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        Task<List<Product>> GetProducts();

        //[OperationContract]
        //Task<Product> AddProduct(Product product);

        //[OperationContract]
        //Task<bool> DeleteProduct(int id);

       








        // Image Methods
        [OperationContract]
        Task<List<WebImage>> GetImagesByProductCode(string productCode);

        [OperationContract]
        Task<List<WebImage>> GetImageByLineNumber(string productCode, int lineNumber);

        [OperationContract]
        Task<List<WebImage>> GetDefaultImage(string productCode);

        [OperationContract]
        Task<WebImage> AddImage(WebImage webImage);

        [OperationContract]
        Task<List<WebImage>> AddImages(List<WebImage> webImages);

        [OperationContract]
        Task<bool> DeleteImage(int imageId);






        //[OperationContract]
        //Task<List<Order>> GetOrders();

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
