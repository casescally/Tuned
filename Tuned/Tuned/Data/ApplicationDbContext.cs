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
        public DbSet<UserEvent> UserEvent { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<LikedCar> LikedCars { get; set; }

                protected override void OnModelCreating (ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        // Create users for Identity Framework
        ApplicationUser user1 = new ApplicationUser {
            FirstName = "Case",
            LastName = "Scally",
            StreetAddress = "123 Infinity Way",
            UserName = "caseScally@gmail.com",
            NormalizedUserName = "CASESCALLY@GMAIL.COM",
            Email = "caseScally@gmail.com",
            NormalizedEmail = "CASESCALLY@GMAIL.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
            Id = "00000000-ffff-ffff-ffff-ffffffffffff"
        };
        var passwordHash1 = new PasswordHasher<ApplicationUser> ();
        user1.PasswordHash = passwordHash1.HashPassword (user1, "Admin8*");
        modelBuilder.Entity<ApplicationUser> ().HasData (user1);

        ApplicationUser user2 = new ApplicationUser {
            FirstName = "Molly",
            LastName = "Scally",
            StreetAddress = "123 Infinity Way",
            UserName = "moScally@gmail.com",
            NormalizedUserName = "MOSCALLY@gmail.com",
            Email = "moScally@gmail.com",
            NormalizedEmail = "MOSCALLY@GMAIL.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
            Id = "e4356622-ec1e-4b02-b5b9-762e4916c2ff"
        };
        var passwordHash2 = new PasswordHasher<ApplicationUser> ();
        user2.PasswordHash = passwordHash2.HashPassword (user2, "Admin9*");
        modelBuilder.Entity<ApplicationUser> ().HasData (user2);

        ApplicationUser user3 = new ApplicationUser {
            FirstName = "Hunter",
            LastName = "K",
            StreetAddress = "249 Brentwood Place",
            UserName = "hunter@gmail.com",
            NormalizedUserName = "HUNTER@GMAIL.COM",
            Email = "hunter@gmail.com",
            NormalizedEmail = "HUNTER@GMAIL.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794579",
            Id = "f5d1aaa8-b80a-4649-bea7-bbc0226c9866"
        };
        var passwordHash3 = new PasswordHasher<ApplicationUser> ();
        user3.PasswordHash = passwordHash3.HashPassword (user3, "Admin10*");
        modelBuilder.Entity<ApplicationUser> ().HasData (user3);
        
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

        modelBuilder.Entity<Car>().HasData(
        new Car
        {
            Id = 2,
            Name = "Genisis",
            Make = "Infiniti",
            Model = "G37",
            Year = 2009,
            Url = 2,
            ApplicationUserId = "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
            VehicleTypeId = 1,
            CarPageCoverUrl = "testUrl2",
            CarDescription = "Molly's Car"
        }
        );
        
        modelBuilder.Entity<Car>().HasData(
        new Car
        {
            Id = 3,
            Name = "Lex",
            Make = "Lexus",
            Model = "IS250",
            Year = 2007,
            Url = 3,
            ApplicationUserId = "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
            VehicleTypeId = 1,
            CarPageCoverUrl = "testUrl3",
            CarDescription = "Hunterz car"
        }
        );



        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 1,
            VehicleTypeName = "Sports Car"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 2,
            VehicleTypeName = "Utility Vehicle"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 3,
            VehicleTypeName = "Sport Utility Vehicle"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 4,
            VehicleTypeName = "Sedan"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 5,
            VehicleTypeName = "Truck"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 6,
            VehicleTypeName = "Hatchback"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 7,
            VehicleTypeName = "Coupe"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 8,
            VehicleTypeName = "Minivan"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 9,
            VehicleTypeName = "Convertible"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 10,
            VehicleTypeName = "Compact Car"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 11,
            VehicleTypeName = "Subcompact Car"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 12,
            VehicleTypeName = "Crossover"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 13,
            VehicleTypeName = "Station Wagon"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 14,
            VehicleTypeName = "Van"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 15,
            VehicleTypeName = "Motorcycle"
        }
        );

        modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType
        {
            Id = 16,
            VehicleTypeName = "Supercar"
        }
        );

       modelBuilder.Entity<Event>().HasData(
        new Event
        {
            Id = 1,
            Name = "Cars and Coffee",
            Location = "Church Street",
            Date = DateTime.Now,
            Description = "Casual meet",
            UserId = "1",
            ImagePath = "SomeTestUrl"
        }
        );

        modelBuilder.Entity<Event>().HasData(
        new Event
        {
            Id = 2,
            Name = "Import Alliance",
            Location = "Atlanta",
            Date = DateTime.Now,
            Description = "Imports only",
            UserId = "3",
            ImagePath = "SomeOtherTestUrl"
        }
        );

        modelBuilder.Entity<Collection>().HasData(
        new Collection
        {
            Id = 1,
            Name = "Cars in my driveway",
            UserId = "1"
        }
        );

        //modelBuilder.Entity<LikedCar>().HasData(
        //new LikedCar
        //{
        //    Id = 1,
        //    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
        //    CarId = 3
        //}
        //);

        modelBuilder.Entity<UserEvent>().HasData(
        new UserEvent
        {
            Id = 1,
            UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
            EventId = 1
        }
        );

        modelBuilder.Entity<UserEvent>().HasData(
        new UserEvent
        {
            Id = 2,
            UserId = "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
            EventId = 2
        }
        );
        }
    }
}
