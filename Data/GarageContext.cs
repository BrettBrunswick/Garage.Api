using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Garage.Api.Models;

namespace Garage.Api.Data
{
    public class GarageContext : IdentityDbContext<Manager>
    {
        public GarageContext(DbContextOptions<GarageContext> options)
            : base(options)
            {
            }

        public GarageContext()
            {
            }

        protected override void OnModelCreating(ModelBuilder builder) {
            
            base.OnModelCreating(builder);
        }
        
        

        public DbSet<Manager> AspNetUsers {get; set;}
        public DbSet<ParkingGarage> Garages { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }

    }
}