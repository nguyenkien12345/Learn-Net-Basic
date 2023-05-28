using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectOfNguyenTrungKien.Models
{
    public class ProductsModel
    {
        public static String dateData = DateTime.Now.ToString("dd/MM/yyyy");
        public static String timeData = DateTime.Now.ToString("HH:mm:ss");

        public Guid Code { get; set; }            // Guid chính là uuid trong nodejs

        public string Name { get; set; }    
        
        public string Description { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public byte Discount { get; set; } = 0;    // Khởi tạo giá trị mặc định cho field Discount

        public bool Active { get; set; } = true;   // Khởi tạo giá trị mặc định cho field Active

        public string Date_Created { get; set; } = dateData;

        public string Time_Created { get; set; } = timeData;

        public string? Date_Updated { get; set; }

        public string? Time_Updated { get; set; }

    }

}
