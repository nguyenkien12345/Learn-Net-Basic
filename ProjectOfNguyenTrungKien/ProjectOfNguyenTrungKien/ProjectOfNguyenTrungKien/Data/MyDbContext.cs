using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ProjectOfNguyenTrungKien.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}

        // Muốn có thể sử dụng tham chiếu / ánh xạ đến bảng nào trong database thì phải khai báo bảng đó vô trong đây
        #region DbSet
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        #endregion
    }
}
