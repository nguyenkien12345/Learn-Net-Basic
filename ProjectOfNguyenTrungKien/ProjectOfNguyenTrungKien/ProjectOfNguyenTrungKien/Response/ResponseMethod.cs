using Microsoft.AspNetCore.Mvc;
using System;
using ProjectOfNguyenTrungKien.Models;

namespace ProjectOfNguyenTrungKien.Response
{
    public class ResponseMethod
    {
        public static String now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        // Hàm chung trả về kết quả thành công
        public OkObjectResult SuccessResponse(Object data)
        {
            var responseData = new ResponseModel
            {
                Status = true,
                Message = "Success",
                Data = data,
                ErrorCode = null
            };

            var result = new OkObjectResult(responseData);

            return result;
        }

        // Hàm chung trả về kết quả thất bại
        public OkObjectResult ErrorResponse(Object error, int errorCode)
        {
            var responseData = new ResponseModel
            {
                Status = false,
                Message = "Fail",
                Data = error,
                ErrorCode = errorCode
            };

            var result = new OkObjectResult(responseData);

            return result;
        }
    }
}
