using Agro.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Context
{
    public interface IProductContext
    {
        List<ProductModel> GetProductListBySearch(ProductModel product);
        List<CategoryModel> GetCategories();
        string SaveProduct(ProductModel product);
        string DeleteProduct(ProductModel product);
        string SaveCategory(CategoryModel category);
        string DeleteCategory(CategoryModel product);
    }
}
