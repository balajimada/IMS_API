using Agro.Context;
using Agro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroServicesAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : AgroControllerBase
    {
        public readonly IProductContext productContext;
        public ProductController(IConfiguration config) : base(config)
        {
            productContext = new ProductContext(base.agroConfig);
        }

        [HttpPost("GetProductsBySearch")]
        public async Task<IActionResult> GetProductsBySearch()
        {
            List<ProductModel> response = new List<ProductModel>();
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(Request.Body);
                string request = await reader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(request))
                {
                    ProductModel productModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductModel>(request);
                    response = productContext.GetProductListBySearch(productModel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPost("SaveProduct")]
        public async Task<IActionResult> SaveProduct()
        {
            string response = string.Empty;
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(Request.Body);
                string request = await reader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(request))
                {
                    ProductModel productModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductModel>(request);
                    response = productContext.SaveProduct(productModel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct()
        {
            string response = string.Empty;
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(Request.Body);
                string request = await reader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(request))
                {
                    ProductModel productModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductModel>(request);
                    response = productContext.DeleteProduct(productModel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPost("GetProductCategories")]
        public async Task<IActionResult> GetProductCategories()
        {
            List<CategoryModel> response = new List<CategoryModel>();
            System.IO.StreamReader reader = new System.IO.StreamReader(Request.Body);
            string request = await reader.ReadToEndAsync();
                
            try
            {
                response = productContext.GetCategories();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPost("SaveCategory")]
        public async Task<IActionResult> SaveCategory()
        {
            string response = string.Empty;
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(Request.Body);
                string request = await reader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(request))
                {
                    CategoryModel category = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryModel>(request);
                    response = productContext.SaveCategory(category);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPost("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory()
        {
            string response = string.Empty;
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(Request.Body);
                string request = await reader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(request))
                {
                    CategoryModel categoryModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryModel>(request);
                    response = productContext.DeleteCategory(categoryModel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

    }
}