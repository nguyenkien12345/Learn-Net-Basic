using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOfNguyenTrungKien.Data;
using ProjectOfNguyenTrungKien.Enum;
using ProjectOfNguyenTrungKien.Models;
using ProjectOfNguyenTrungKien.Response;
using System;
using System.Xml.Linq;

namespace ProjectOfNguyenTrungKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static ResponseMethod responseMethod = new ResponseMethod();
        private readonly MyDbContext _context;
        public static String dateData = DateTime.Now.ToString("dd/MM/yyyy");
        public static String timeData = DateTime.Now.ToString("HH:mm:ss");

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        // Tất cả các hàm trong đây đều phải khai báo [] không thì sẽ lỗi khi generate ra swagger
        // Chúng ta không muốn hiển thị api nào ra swagger thì để prive thay vì public

        [HttpGet("CheckExist/{name}")]
        private Products CheckProductExists(string name)
        {
            var product = _context.Products.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefault();
            if(product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        // Lấy ra tất cả các sản phẩm
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return responseMethod.SuccessResponse((Object)_context.Products.ToList());
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
                var product = _context.Products.SingleOrDefault(x => x.Code == Guid.Parse(id));

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
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_PRODUCT);
            }
        }

        // Thêm sản phẩm
        [HttpPost]
        public IActionResult Create(ProductsModel productModel)
        {
            // Lưu ý
            // product truyền tham số là ProductsModel trong Models chứ không phải Products trong Data
            try
            {
                var checkExists = CheckProductExists(productModel.Name);
                if (checkExists != null)
                {
                    return responseMethod.ErrorResponse(checkExists, (int)ErrorCodeExists.EXISTS_PRODUCT);
                }

                var newProduct = new Products
                {
                    Code = Guid.NewGuid(),
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Quantity = productModel.Quantity,
                    Active = productModel.Active,
                    Price = productModel.Price,
                    Discount = productModel.Discount,
                };

                _context.Products.Add(newProduct);
                _context.SaveChanges();

                return responseMethod.SuccessResponse(newProduct);
            }
            catch (Exception ex)
            {
                //return BadRequest();
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_PRODUCT);
            }
        }

        // Cập nhật sản phẩm
        [HttpPut("{id}")]
        public IActionResult Update(string id, ProductsModel newProductModel)
        {
            try
            {
                var oldProduct = _context.Products.SingleOrDefault(x => x.Code == Guid.Parse(id));

                if (oldProduct != null)
                {
                    var checkExists = CheckProductExists(newProductModel.Name);
                    if (checkExists != null)
                    {
                        return responseMethod.ErrorResponse(checkExists, (int)ErrorCodeExists.EXISTS_PRODUCT);
                    }

                    oldProduct.Code = Guid.NewGuid();
                    oldProduct.Name = newProductModel.Name;
                    oldProduct.Description = newProductModel.Description;
                    oldProduct.Quantity = newProductModel.Quantity;
                    oldProduct.Active = newProductModel.Active;
                    oldProduct.Price = newProductModel.Price;
                    oldProduct.Discount = newProductModel.Discount;
                    oldProduct.Time_Updated = timeData;
                    oldProduct.Date_Updated = dateData;
                    
                    
                    _context.SaveChanges();

                    //return NoContent();
                    return responseMethod.SuccessResponse(newProductModel);
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
                var product = _context.Products.SingleOrDefault(x => x.Code == Guid.Parse(id));

                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();

                    //return NoContent();
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
