using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProductService
{
    public class ProductService : IProductService
    {
        // class variables
        SqlConnection conn;
        SqlCommand comm;

        // constructor NOTE: setting up DB here instead, as did not want expose a DB setup method to client
        public ProductService()
        {
            SetupDB();
        }

        // setup the database
        private void SetupDB()
        {
            try
            {
                // connecto to local db
                conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\tp\totalproducecodingchallenge\ProductService\ProductService\ProductsDb.mdf;Integrated Security = True;Connect Timeout = 30");
                comm = conn.CreateCommand();

                conn.Open();

                // create table if it does not exist. NOTE: Be careful with clearing table i.e. DROP TABLE Products. Constructor is called at each request == db cleared every time
                comm = new SqlCommand("IF OBJECT_ID('Products') IS NOT NULL CREATE TABLE Products(ProductId int, ProductName char(50), ProductType char(50), ProductDescription char(50), ProductPrice decimal(5,2));", conn);
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        // get all products
        public List<Product> GetAllProducts()
        {
            return RetrieveProductsList("SELECT * FROM Products");
        }

        // get all product with specific id. NOTE: again, duplicates allowed in insert
        public List<Product> GetProductsById(int productIdIn)
        {
            return RetrieveProductsList("SELECT * FROM Products WHERE ProductId = " + productIdIn);
        }

        private List<Product> RetrieveProductsList(string SqlQueryIn)
        {
            try
            {
                comm = new SqlCommand(SqlQueryIn, conn);

                List<Product> productsList = new List<Product>();


                conn.Open();

                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProductId = int.Parse(dr[0].ToString());
                    p.ProductName = dr[1].ToString();
                    p.ProductType = dr[2].ToString();
                    p.ProductDescription = dr[3].ToString();
                    p.ProductPrice = double.Parse(dr[4].ToString());

                    productsList.Add(p);
                }
                conn.Close();
                return productsList;
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving list of products" + e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
        
        // insert product. NOTE: duplicate IDs allowed for this example
        public void InsertProduct(int productIdIn, string productNameIn, string productTypeIn, string productDescriptionIn, double productPriceIn)
        {
            try
            {
                comm.CommandText = "INSERT INTO Products VALUES(@ProductId, @ProductName, @ProductType, @ProductDescription, @ProductPrice)";
                comm.Parameters.AddWithValue("ProductId", productIdIn);
                comm.Parameters.AddWithValue("ProductName", productNameIn);
                comm.Parameters.AddWithValue("ProductType", productTypeIn);
                comm.Parameters.AddWithValue("ProductDescription", productDescriptionIn);
                comm.Parameters.AddWithValue("ProductPrice", productPriceIn);
                comm.CommandType = CommandType.Text;

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error with product insertion: " + e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        // update product
        public void UpdateProduct(int productIdIn, string productNameIn, string productTypeIn, string productDescriptionIn, double productPriceIn)
        {
            try
            {
                comm.CommandText = "UPDATE Products SET ProductName=@ProductName, ProductType=@ProductType, ProductDescription=@ProductDescription, ProductPrice=@ProductPrice WHERE ProductId=@ProductId";
                comm.Parameters.AddWithValue("ProductId", productIdIn);
                comm.Parameters.AddWithValue("ProductName", productNameIn);
                comm.Parameters.AddWithValue("ProductType", productTypeIn);
                comm.Parameters.AddWithValue("ProductDescription", productDescriptionIn);
                comm.Parameters.AddWithValue("ProductPrice", productPriceIn);
                comm.CommandType = CommandType.Text;

                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error with product update: " + e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        // delete product
        public void DeleteProduct(int productIdIn)
        {
            try
            {
                comm.CommandText = "DELETE Products WHERE ProductId=@ProductId";
                comm.Parameters.AddWithValue("ProductId", productIdIn);
                comm.CommandType = CommandType.Text;
                conn.Open();

                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error with product deletion: " + e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
    }
}
