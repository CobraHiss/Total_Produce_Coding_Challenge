using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        // get all products
        [OperationContract]
        List<Product> GetAllProducts();

        // get all products with specific id
        [OperationContract]
        List<Product> GetProductsById(int productIdIn);

        // insert product
        [OperationContract]
        void InsertProduct(int productIdIn, string productNameIn, string productTypeIn, string productDescriptionIn, double productPriceIn);

        // update product
        [OperationContract]
        void UpdateProduct(int productIdIn, string productNameIn, string productTypeIn, string productDescriptionIn, double productPriceIn);

        // delete product
        [OperationContract]
        void DeleteProduct(int productIdIn);
    }
}
