using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using ProductClient.ProductServiceRef;
using System.Collections.ObjectModel;

namespace ProductClient.ViewModels
{
    [POCOViewModel]
    public class ProductsListsViewModel
    {
        public virtual ObservableCollection<Product> ProductsList { get; set; }

        protected ProductsListsViewModel()
        {
            IProductService p = new ProductServiceClient();

            ProductsList = new ObservableCollection<Product>();

            foreach (var productItem in p.GetAllProducts())
            {
                ProductsList.Add(new ProductClient.Product(productItem.ProductId, productItem.ProductName, productItem.ProductType, productItem.ProductDescription, productItem.ProductPrice));
                System.Diagnostics.Debug.WriteLine(productItem.ProductName);
            }
        }

        public static ProductsListsViewModel Create()
        {
            return ViewModelSource.Create(() => new ProductsListsViewModel());
        }
    }
}