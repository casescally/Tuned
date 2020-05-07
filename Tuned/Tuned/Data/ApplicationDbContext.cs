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
    }
}
