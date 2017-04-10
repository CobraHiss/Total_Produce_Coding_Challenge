using System;
using System.ComponentModel;

namespace ProductClient
{
    public class Product : INotifyPropertyChanged
    {
        public Product(int productIdin, string productNameIn, string productTypeIn, string productDescriptionIn, double productPriceIn)
        {
            this.ProductId = productIdin;
            this.ProductName = productNameIn;
            this.ProductType = productTypeIn;
            this.ProductDescription = productDescriptionIn;
            this.ProductPrice = productPriceIn;
        }
        
        private int productId;
        public int ProductId
        {
            get { return productId; }
            set
            {
                if (productId == value)
                    return;
                productId = value;
                OnPropertyChanged("ProductId");
            }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                if (productName == value)
                    return;
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        private string productType;
        public string ProductType
        {
            get { return productType; }
            set
            {
                if (productType == value)
                    return;
                productType = value;
                OnPropertyChanged("ProductType");
            }
        }

        private string productDescription;
        public string ProductDescription
        {
            get { return productDescription; }
            set
            {
                if (productDescription == value)
                    return;
                productDescription = value;
                OnPropertyChanged("ProductDescription");
            }
        }

        private double productPrice;
        public double ProductPrice
        {
            get { return productPrice; }
            set
            {
                if (productPrice == value)
                    return;
                productPrice = value;
                OnPropertyChanged("ProductPrice");
            }
        }

        private void OnPropertyChanged(string v)
        {}

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {}

            remove
            {}
        }
    }
}