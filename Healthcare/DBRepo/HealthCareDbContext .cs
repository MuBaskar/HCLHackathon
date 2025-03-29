

using Microsoft.EntityFrameworkCore;
using model;

namespace DBRepo
{
    public class HealthCareDbContext :DbContext
{
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
    
                optionsBuilder.UseSqlServer("Server=DESKTOP-M0DCM1O;Database=HealthCare;Trusted_Connection=True; Encrypt=false");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}
}
