namespace ProjectOfNguyenTrungKien.Models
{

    public class Products
    {
        public Guid Code { get; set; }          // Guid chính là uuid trong nodejs
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
    }

}
