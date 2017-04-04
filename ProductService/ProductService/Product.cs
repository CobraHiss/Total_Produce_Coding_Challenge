using System.Runtime.Serialization;

namespace ProductService
{
    // product model
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string ProductType { get; set; }

        [DataMember]
        public string ProductDescription { get; set; }

        [DataMember]
        public double ProductPrice { get; set; }
    }
}