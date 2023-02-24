using Microsoft.EntityFrameworkCore;
using ApiVue.Entities;

namespace ApiVue.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Articulo> Articulos { get; set; }
    }
}