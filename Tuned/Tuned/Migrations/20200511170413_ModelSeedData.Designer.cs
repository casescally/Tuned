﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tuned.Data;

namespace Tuned.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200511170413_ModelSeedData")]
    partial class ModelSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Tuned.Models.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileBackgroundPicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileHeader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5aac903e-2767-4a58-a95b-6173999e08b5",
                            Email = "caseScally@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Case",
                            LastName = "Scally",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "CASESCALLY@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDGrqRVI7nvRK1t8+78fUYunKbgrd9Hrxtkhxpo7wjvG5PS4y8R7LAz337zDCoSgGA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                            StreetAddress = "123 Infinity Way",
                            TwoFactorEnabled = false,
                            UserName = "caseScally@gmail.com"
                        },
                        new
                        {
                            Id = "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "09c292a4-217e-436a-99f7-3c049d79d1b7",
                            Email = "caseScally@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Molly",
                            LastName = "Scally",
                            LockoutEnabled = false,
                            NormalizedEmail = "MOSCALLY@GMAIL.COM",
                            NormalizedUserName = "MOSCALLY@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHBQo5+G5rDpGZ0iSxz7LVvMWsuIcI9MYBMs8voUDxPQ+0WmnofnyPP/8uUNc972CA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
                            StreetAddress = "123 Infinity Way",
                            TwoFactorEnabled = false,
                            UserName = "moScally@gmail.com"
                        },
                        new
                        {
                            Id = "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e3123dfa-a70f-4bf4-9895-7d8b5c3c1f02",
                            Email = "hunter@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Hunter",
                            LastName = "K",
                            LockoutEnabled = false,
                            NormalizedEmail = "HUNTER@GMAIL.COM",
                            NormalizedUserName = "HUNTER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEXcQLdm1Hsbp+17Mdc0dJgGW8a4LeCB/QJTnPGBuPZD9a2ChNjsAcDoHgl4KY+PBQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794579",
                            StreetAddress = "249 Brentwood Place",
                            TwoFactorEnabled = false,
                            UserName = "hunter@gmail.com"
                        });
                });

            modelBuilder.Entity("Tuned.Models.Data.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarPageCoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Url")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            CarDescription = "My car",
                            CarPageCoverUrl = "testUrl",
                            Make = "Infiniti",
                            Model = "G37",
                            Name = "G",
                            Url = 1,
                            VehicleTypeId = 1,
                            Year = 2012
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                            CarDescription = "Molly's Car",
                            CarPageCoverUrl = "testUrl2",
                            Make = "Infiniti",
                            Model = "G37",
                            Name = "Genisis",
                            Url = 2,
                            VehicleTypeId = 1,
                            Year = 2009
                        },
                        new
                        {
                            Id = 3,
                            ApplicationUserId = "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                            CarDescription = "Hunterz car",
                            CarPageCoverUrl = "testUrl3",
                            Make = "Lexus",
                            Model = "IS250",
                            Name = "Lex",
                            Url = 3,
                            VehicleTypeId = 1,
                            Year = 2007
                        });
                });

            modelBuilder.Entity("Tuned.Models.Data.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarImages");
                });

            modelBuilder.Entity("Tuned.Models.Data.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Collections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cars in my driveway",
                            UserId = "1"
                        });
                });

            modelBuilder.Entity("Tuned.Models.Data.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminUserId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 5, 11, 10, 4, 13, 136, DateTimeKind.Local).AddTicks(8724),
                            Description = "Casual meet",
                            ImagePath = "SomeTestUrl",
                            Location = "Church Street",
                            Name = "Cars and Coffee",
                            UserId = "1"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2020, 5, 11, 10, 4, 13, 137, DateTimeKind.Local).AddTicks(6999),
                            Description = "Imports only",
                            ImagePath = "SomeOtherTestUrl",
                            Location = "Atlanta",
                            Name = "Import Alliance",
                            UserId = "3"
                        });
                });

            modelBuilder.Entity("Tuned.Models.Data.LikedCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId1");

                    b.ToTable("LikedCars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 3,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Tuned.Models.Data.RefreshToken", b =>
                {
                    b.Property<Guid>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Invalidated")
                        .HasColumnType("bit");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TokenId");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Tuned.Models.Data.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VehicleTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            VehicleTypeName = "Sports Car"
                        },
                        new
                        {
                            Id = 2,
                            VehicleTypeName = "Utility Vehicle"
                        },
                        new
                        {
                            Id = 3,
                            VehicleTypeName = "Sport Utility Vehicle"
                        },
                        new
                        {
                            Id = 4,
                            VehicleTypeName = "Sedan"
                        },
                        new
                        {
                            Id = 5,
                            VehicleTypeName = "Truck"
                        },
                        new
                        {
                            Id = 6,
                            VehicleTypeName = "Hatchback"
                        },
                        new
                        {
                            Id = 7,
                            VehicleTypeName = "Coupe"
                        },
                        new
                        {
                            Id = 8,
                            VehicleTypeName = "Minivan"
                        },
                        new
                        {
                            Id = 9,
                            VehicleTypeName = "Convertible"
                        },
                        new
                        {
                            Id = 10,
                            VehicleTypeName = "Compact Car"
                        },
                        new
                        {
                            Id = 11,
                            VehicleTypeName = "Subcompact Car"
                        },
                        new
                        {
                            Id = 12,
                            VehicleTypeName = "Crossover"
                        },
                        new
                        {
                            Id = 13,
                            VehicleTypeName = "Station Wagon"
                        },
                        new
                        {
                            Id = 14,
                            VehicleTypeName = "Van"
                        },
                        new
                        {
                            Id = 15,
                            VehicleTypeName = "Motorcycle"
                        },
                        new
                        {
                            Id = 16,
                            VehicleTypeName = "Supercar"
                        });
                });

            modelBuilder.Entity("Tuned.Models.ViewModels.ApplicationUserViewModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUserViewModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Tuned.Models.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Tuned.Models.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tuned.Models.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Tuned.Models.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tuned.Models.Data.Car", b =>
                {
                    b.HasOne("Tuned.Models.Data.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Tuned.Models.Data.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tuned.Models.Data.CarImage", b =>
                {
                    b.HasOne("Tuned.Models.Data.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tuned.Models.Data.Collection", b =>
                {
                    b.HasOne("Tuned.Models.Data.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Tuned.Models.Data.Event", b =>
                {
                    b.HasOne("Tuned.Models.ViewModels.ApplicationUserViewModel", "AdminUser")
                        .WithMany()
                        .HasForeignKey("AdminUserId");
                });

            modelBuilder.Entity("Tuned.Models.Data.LikedCar", b =>
                {
                    b.HasOne("Tuned.Models.Data.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tuned.Models.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Tuned.Models.Data.RefreshToken", b =>
                {
                    b.HasOne("Tuned.Models.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
