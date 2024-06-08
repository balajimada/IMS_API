using Agro.Model;
using System;
using System.Collections.Generic;

namespace Agro.Context
{

    public class ProductContext : IProductContext
    {
        Agro.Utitlity.Configuration _Config;
        Agro.DataAccess.ProductDB productDB;
        
        public ProductContext(Agro.Utitlity.Configuration config)
        {
            _Config = config;
            productDB = new DataAccess.ProductDB(_Config);
        }
        public List<ProductModel> GetProductListBySearch(ProductModel product)
        {
            return this.productDB.GetProductListBySearch(product);
        }
        public List<CategoryModel> GetCategories()
        {
            return this.productDB.GetCategories();
        }

        public string SaveProduct(ProductModel product)
        {
            return this.productDB.SaveProduct(product);
        }

        public string DeleteProduct(ProductModel product)
        {
            return this.productDB.DeleteProduct(product);
        }

        public string SaveCategory(CategoryModel category)
        {
            return this.productDB.SaveCategory(category);
        }

        public string DeleteCategory(CategoryModel category)
        {
            return this.productDB.DeleteCategory(category);
        }



    }
}
