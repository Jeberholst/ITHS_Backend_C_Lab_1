using Microsoft.EntityFrameworkCore;

namespace ITHS_Backend_C_Lab_1.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        
        
        //private string _connectionString = "server=localhost;user=joakim;password=123456";
        private string _connectionString = "server=localhost;user=root;database=animalcollection; password=Suckel;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString));
        }
    }
}