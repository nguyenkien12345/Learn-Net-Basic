namespace ProjectOfNguyenTrungKien.Models
{
    public class ResponseData
    {
        public static String now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        public bool Status { get; set; }          
        public string Message { get; set; }
        public object Data { get; set; }
        public string DateTimeResponse { get; set; } = now; // Khởi tạo giá trị mặc định cho field DateTimeResponse
        public int? ErrorCode { get; set; }                 // Field này có thể có hoặc không có
    }
}
