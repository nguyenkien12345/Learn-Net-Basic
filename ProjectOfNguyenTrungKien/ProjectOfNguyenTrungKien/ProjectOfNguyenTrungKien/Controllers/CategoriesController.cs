using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOfNguyenTrungKien.Data;
using ProjectOfNguyenTrungKien.Enum;
using ProjectOfNguyenTrungKien.Models;
using ProjectOfNguyenTrungKien.Response;
using System;

namespace ProjectOfNguyenTrungKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public static ResponseMethod responseMethod = new ResponseMethod();
        private readonly MyDbContext _context;
        public static String dateData = DateTime.Now.ToString("dd/MM/yyyy");
        public static String timeData = DateTime.Now.ToString("HH:mm:ss");

        public CategoriesController(MyDbContext context)
        {
            _context = context;
        }

        // Tất cả các hàm trong đây đều phải khai báo [] không thì sẽ lỗi khi generate ra swagger
        // Chúng ta không muốn hiển thị api nào ra swagger thì để prive thay vì public

        [HttpGet("CheckExist/{name}")]
        private Categories CheckCategoryExists(string name)
        {
            var category = _context.Categories.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefault();
            if (category != null)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        // Lấy ra tất cả các danh mục
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return responseMethod.SuccessResponse(_context.Categories.ToList());
            }
            catch (Exception ex)
            {
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_CATEGORY);
            }
        }

        // Lấy ra danh mục chi tiết
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(x => x.CodeCategory == Guid.Parse(id));

                if (category != null)
                {
                    return responseMethod.SuccessResponse(category);
                }
                else
                {
                    return responseMethod.ErrorResponse(null, (int)ErrorCodeNotFound.NOT_FOUND_CATEGORY);
                }
            }
            catch (Exception ex)
            {
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_CATEGORY);
            }
        }

        // Thêm danh mục
        [HttpPost]
        public IActionResult Create(CategoriesModel categoryModel)
        {
            try
            {
                var checkExists = CheckCategoryExists(categoryModel.Name);
                if (checkExists != null)
                {
                    return responseMethod.ErrorResponse(checkExists, (int)ErrorCodeExists.EXISTS_CATEGORY);
                }

                var newCategory = new Categories
                {
                    CodeCategory = Guid.NewGuid(),
                    Name = categoryModel.Name,
                    Description = categoryModel.Description
                };

                _context.Categories.Add(newCategory);
                _context.SaveChanges();

                return responseMethod.SuccessResponse(newCategory);
            }
            catch (Exception ex)
            {
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_CATEGORY);
            }
        }

        // Cập nhật danh mục
        [HttpPut("{id}")]
        public IActionResult Update(string id, CategoriesModel categoryModel)
        {
            try
            {
                var oldCategory = _context.Categories.SingleOrDefault(x => x.CodeCategory == Guid.Parse(id));

                if (oldCategory != null)
                {
                    var checkExists = CheckCategoryExists(categoryModel.Name);
                    if (checkExists != null)
                    {
                        return responseMethod.ErrorResponse(checkExists, (int)ErrorCodeExists.EXISTS_CATEGORY);
                    }

                    oldCategory.Name = categoryModel.Name;
                    oldCategory.Description = categoryModel.Description;
                    oldCategory.Time_Updated = timeData;
                    oldCategory.Date_Updated = dateData;

                    _context.SaveChanges();

                    return responseMethod.SuccessResponse(categoryModel);
                }
                else
                {
                    return responseMethod.ErrorResponse(null, (int)ErrorCodeNotFound.NOT_FOUND_CATEGORY);
                }
            }
            catch (Exception ex)
            {
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_CATEGORY);
            }
        }

        // Xóa danh mục
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(x => x.CodeCategory == Guid.Parse(id));

                if (category != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();

                    return responseMethod.SuccessResponse(category);
                }
                else
                {
                    //return NotFound(); 
                    return responseMethod.ErrorResponse(null, (int)ErrorCodeNotFound.NOT_FOUND_CATEGORY);
                }
            }
            catch (Exception ex)
            {
                //return BadRequest();
                return responseMethod.ErrorResponse(ex.Message, (int)ErrorCodeBadRequest.BAD_REQUEST_CATEGORY);
            }
        }
    }
}
