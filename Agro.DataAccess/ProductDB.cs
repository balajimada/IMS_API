using Agro.Model;
using Agro.Utitlity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Agro.DataAccess
{
    public class ProductDB
    {
        private Agro.Utitlity.Configuration _Config;
        public ProductDB(Agro.Utitlity.Configuration config)
        {
            _Config = config;
        }
        public string SaveProduct(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(_Config.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_SaveProdcutDetails";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;                    
                    cmd.Parameters.Add(new SqlParameter("@ProductID", product.ProductID));
                    cmd.Parameters.Add(new SqlParameter("@CategoryCode", product.CategoryCode));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                    cmd.Parameters.Add(new SqlParameter("@ProductImage", product.ProductImage));
                    cmd.Parameters.Add(new SqlParameter("@ProductDescr", product.ProductDescr));
                    cmd.Parameters.Add(new SqlParameter("@ProductTags", product.ProductTags));
                    cmd.Parameters.Add(new SqlParameter("@ReceviedCost", product.ReceviedCost));
                    cmd.Parameters.Add(new SqlParameter("@ProfitMargin", product.ProfitMargin));
                    cmd.Parameters.Add(new SqlParameter("@TotalPrice", product.TotalPrice));                    
                    cmd.Parameters.Add(new SqlParameter("@CreatedBy", product.CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("@ModifiedBy", product.ModifiedBy));

                    int result = cmd.ExecuteNonQuery();
                    return result.ToString();
                }
            }
        }
        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            using (SqlConnection conn = new SqlConnection(_Config.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_GetProductCategories";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new CategoryModel()
                        {
                            CategoryID = Convert.ToInt64(dr["CategoryID"]),
                            CategoryCode = dr["CategoryCode"].ToStr(),
                            CategoryName = dr["CategoryName"].ToStr(),
                            GST = Convert.ToDecimal(dr["GST"])
                        });
                    }

                }
            }
            return list;
        }
        public List<ProductModel> GetProductListBySearch(ProductModel product)
        {
            List<ProductModel> list = new List<ProductModel>();
            using (SqlConnection conn = new SqlConnection(_Config.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_GetProductListBySearch";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SearchStr", product.ProductName));
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new ProductModel()
                        {
                            ProductID = Convert.ToInt64(dr["ProductID"]),
                            CategoryCode = dr["CategoryCode"].ToStr(),
                            ProductName = dr["ProductName"].ToStr(),
                            ProductImage = dr["ProductImage"].ToStr(),
                            ProductDescr = dr["ProductDescr"].ToStr(),
                            ProductTags = dr["ProductTags"].ToStr(),
                            CategoryName = dr["CategoryName"].ToStr(),
                            ReceviedCost = dr["ReceviedCost"].ToDecimal(),
                            ProfitMargin = dr["ProfitMargin"].ToDecimal(),
                            TotalPrice = dr["TotalPrice"].ToDecimal()
                        });
                    }

                }
            }
            return list;
        }
        public string DeleteProduct(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(_Config.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_DeleteProduct";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductID", product.ProductID));
                    int result = cmd.ExecuteNonQuery();
                    return result.ToString();
                }
            }
        }
        public string DeleteCategory(CategoryModel category)
        {
            using (SqlConnection conn = new SqlConnection(_Config.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_DeleteCategory";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryID", category.CategoryID));
                    int result = cmd.ExecuteNonQuery();
                    return result.ToString();
                }
            }
        }
        public string SaveCategory(CategoryModel category)
        {
            using (SqlConnection conn = new SqlConnection(_Config.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_SaveCategoryDetails";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryID", category.CategoryID));
                    cmd.Parameters.Add(new SqlParameter("@CategoryCode", category.CategoryCode));
                    cmd.Parameters.Add(new SqlParameter("@CategoryName", category.CategoryName));                    
                    cmd.Parameters.Add(new SqlParameter("@GST", category.GST));
                    cmd.Parameters.Add(new SqlParameter("@CreatedBy", category.CreatedBy));
                    cmd.Parameters.Add(new SqlParameter("@ModifiedBy", category.ModifiedBy));

                    int result = cmd.ExecuteNonQuery();
                    return result.ToString();
                }
            }
        }
    }
}
