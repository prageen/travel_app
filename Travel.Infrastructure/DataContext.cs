using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure.Trip;

namespace Travel.Infrastructure
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //public DbSet<User> User { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Enquiry> Enquiry { get; set; }
        public DbSet<Party> Party { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Terms> Terms { get; set; }
        public DbSet<TripDetails> Trip { get; set; }
        public DbSet<TripCategory> TripCategory { get; set; }
        public DbSet<VehicleMaster> VehicleMaster { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleExpence > VehicleExpence { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //// Configure the identity system models
            //modelBuilder.Entity<IdentityUser>().ToTable("Users");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }

    }
}
