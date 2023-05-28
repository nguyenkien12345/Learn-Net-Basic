namespace ProjectOfNguyenTrungKien.Models
{
    public class CategoriesModel
    {
        public static String dateData = DateTime.Now.ToString("dd/MM/yyyy");
        public static String timeData = DateTime.Now.ToString("HH:mm:ss");

        public Guid Code { get; set; }            // Guid chính là uuid trong nodejs

        public string Name { get; set; }

        public string Description { get; set; }

        public string Date_Created { get; set; } = dateData;

        public string Time_Created { get; set; } = timeData;

        public string? Date_Updated { get; set; }

        public string? Time_Updated { get; set; }
    }
}
