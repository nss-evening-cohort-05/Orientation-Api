using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class ProductDataAccess : IProductRepository<ProductListResult>
    {
        public List<ProductListResult> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<ProductListResult> CreateProduct()
        {
            throw new NotImplementedException();
        }

        public List<ProductListResult> DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public bool MarkOutOfStock(int entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
    public interface IProductRepository<T>
    {
        List<T> GetAllProducts();
        List<T> CreateProduct();
        List<T> DeleteProduct();
        bool MarkOutOfStock(int entityToUpdate);
    }
}