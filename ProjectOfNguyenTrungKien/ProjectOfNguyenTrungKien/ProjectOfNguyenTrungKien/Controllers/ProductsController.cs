using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOfNguyenTrungKien.Enum;
using ProjectOfNguyenTrungKien.Models;
using ProjectOfNguyenTrungKien.Response;
using System;

namespace ProjectOfNguyenTrungKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Products> products = new List<Products>();
        public static ResponseMethod responseMethod = new ResponseMethod();

        // Lấy ra tất cả các sản phẩm
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return responseMethod.SuccessResponse(products);
            }
            catch (Exception ex)
            {
                //return BadRequest();
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_PRODUCT);
            }
        }


        // Lấy ra sản phẩm chi tiết
        [HttpGet("{id}")]
        public IActionResult GetById(string id) 
        {
            try
            {
                var product = products.SingleOrDefault(x => x.Code == Guid.Parse(id));

                if (product != null)
                {
                    return responseMethod.SuccessResponse(product);
                }
                else
                {
                    //return NotFound(); 
                    return responseMethod.ErrorResponse(null, (int)ErrorCodeNotFound.NOT_FOUND_PRODUCT);
                }
            }
            catch (Exception ex)
            {
                //return BadRequest();
                return responseMethod.ErrorResponse(ex.Message,(int)ErrorCodeBadRequest.BAD_REQUEST_PRODUCT);
            }
        }

        // Thêm sản phẩm
        [HttpPost]
        public IActionResult Create(Products product)
        {
            try
            {
                var newProduct = new Products
                {
                    Code = Guid.NewGuid(),
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Active = product.Active,
                };
                products.Add(newProduct);

                return responseMethod.SuccessResponse(newProduct);
            }
            catch(Exception ex)
            {
                //return BadRequest();
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_PRODUCT);
            }
        }

        // Cập nhật sản phẩm
        [HttpPut("{id}")]
        public IActionResult Update(string id, Products newProduct)
        {
            try
            {
                var oldProduct = products.SingleOrDefault(x => x.Code == Guid.Parse(id));

                if (oldProduct != null)
                {
                    oldProduct.Name = newProduct.Name;
                    oldProduct.Quantity = newProduct.Quantity;
                    oldProduct.Active = newProduct.Active;

                    return responseMethod.SuccessResponse(newProduct);
                }
                else
                {
                    //return NotFound(); 
                    return responseMethod.ErrorResponse(null, (int)ErrorCodeNotFound.NOT_FOUND_PRODUCT);
                }
            }
            catch (Exception ex)
            {
                //return BadRequest();
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_PRODUCT);
            }
        }

        // Xóa sản phẩm
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var product = products.SingleOrDefault(x => x.Code == Guid.Parse(id));

                if (product != null)
                {
                   products.Remove(product);
                   return responseMethod.SuccessResponse(product);
                }
                else
                {
                    //return NotFound(); 
                    return responseMethod.ErrorResponse(null, (int)ErrorCodeNotFound.NOT_FOUND_PRODUCT);
                }
            }
            catch (Exception ex)
            {
                //return BadRequest();
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_PRODUCT);
            }
        }
    }
}
