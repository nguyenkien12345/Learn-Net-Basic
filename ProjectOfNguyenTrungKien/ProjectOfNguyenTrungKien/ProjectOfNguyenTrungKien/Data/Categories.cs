using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectOfNguyenTrungKien.Data
{
    // Đặt tên bảng là Categories
    [Table("Categories")]
    public class Categories
    {
        public static String dateData = DateTime.Now.ToString("dd/MM/yyyy");
        public static String timeData = DateTime.Now.ToString("HH:mm:ss");

        [Key]
        public Guid CodeCategory { get; set; }            // Guid chính là uuid trong nodejs

        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Name { get; set; }

        public string? Description { get; set; }

        // 1 Category thì có thể có nhiều Product
        // Thường trả về Dạng mảng nhiều phần tử sẽ dùng ICollection
        public virtual ICollection<Products> Products { get; set; }

        public string Date_Created { get; set; } = dateData;

        public string Time_Created { get; set; } = timeData;

        public string? Date_Updated { get; set; }

        public string? Time_Updated { get; set; }
    }
}
