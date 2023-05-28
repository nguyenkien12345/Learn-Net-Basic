using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectOfNguyenTrungKien.Data
{
    // Đặt tên bảng là Products
    [Table("Products")]
    public class Products
    {
        public static String dateData = DateTime.Now.ToString("dd/MM/yyyy");
        public static String timeData = DateTime.Now.ToString("HH:mm:ss");

        [Key]
        public Guid Code { get; set; }            // Guid chính là uuid trong nodejs

        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(10, 1000)]
        public int Quantity { get; set; }

        [Required]
        [Range(1000, double.MaxValue)]            // Min là 1000, Max là giá trị mà double quy định
        public double Price { get; set; }

        [Required]
        [Range(0, 100)]
        public byte Discount { get; set; } = 0;   // Khởi tạo giá trị mặc định cho field Discount

        public bool Active { get; set; } = true;  // Khởi tạo giá trị mặc định cho field Active

        public string Date_Created { get; set; } = dateData;

        public string Time_Created { get; set; } = timeData;

        public string? Date_Updated { get; set; }

        public string? Time_Updated { get; set; }

        // Khai báo khóa ngoại CodeCategory (Lưu ý phải cùng kiểu dữ liệu) tham chiếu đến bảng Categories
        // 1 Product chỉ thuộc 1 Category
        public Guid? CodeCategory { get; set; }
        [ForeignKey("CodeCategory")]
        public Categories Categories { get; set; }
    }

}
