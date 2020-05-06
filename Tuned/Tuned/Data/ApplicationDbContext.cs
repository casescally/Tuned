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
        public DbSet<Car> Cars { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}
