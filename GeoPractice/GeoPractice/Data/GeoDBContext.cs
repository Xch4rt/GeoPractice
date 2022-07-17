using Microsoft.EntityFrameworkCore;

namespace GeoPractice.Data
{
    public class GeoDBContext : DbContext
    {
        public GeoDBContext(DbContextOptions<GeoDBContext> options) : base(options)
        { }

       public DbSet<tblUser> Usuario { get; set; }

        public DbSet<tblGeodata> GeorReferencia { get; set; }
    }
}
