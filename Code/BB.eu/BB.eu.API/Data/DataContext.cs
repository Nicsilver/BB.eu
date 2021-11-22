using BB.eu.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BB.eu.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BB.eu;Trusted_Connection=True;");
        }
    }
}