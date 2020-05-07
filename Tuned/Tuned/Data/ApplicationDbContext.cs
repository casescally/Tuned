using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tuned.Models.Data;

namespace Tuned.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<CarImage> CarImage { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<VehicleType> CarCollection { get; set; }
        public DbSet<VehicleType> UserEvent { get; set; }
        public DbSet<VehicleType> LikedCar { get; set; }
        
 protected override void OnModelCreating (ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        // Create a new user for Identity Framework
        ApplicationUser user = new ApplicationUser {
            FirstName = "Case",
            LastName = "Scally",
            StreetAddress = "123 Infinity Way",
            UserName = "caseScally@gmail.com",
            NormalizedUserName = "CASESCALLY@CASESCALLY.COM",
            Email = "caseScally@gmail.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
            Id = "00000000-ffff-ffff-ffff-ffffffffffff"
        };
        var passwordHash = new PasswordHasher<ApplicationUser> ();
        user.PasswordHash = passwordHash.HashPassword (user, "Admin8*");
        modelBuilder.Entity<ApplicationUser> ().HasData (user);
        
        modelBuilder.Entity<Car>().HasData(
        new Car
        {
            Id = 1,
            Name = "G",
            Make = "Infiniti",
            Model = "G37",
            Year = 2012,
            Url = 1,
            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
            VehicleTypeId = 1,
            CarPageCoverUrl = "testUrl",
            CarDescription = "My car"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 1,
            VehicleTypeName = "Sports Car"
        }
        );
        }
    }
}
