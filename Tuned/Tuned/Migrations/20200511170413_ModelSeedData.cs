using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class ModelSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileBackgroundPicturePath",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileHeader",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    AdminUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_ApplicationUserViewModel_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "ApplicationUserViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Url = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    CarPageCoverUrl = table.Column<string>(nullable: true),
                    CarDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImages_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikedCars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikedCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedCars_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileBackgroundPicturePath", "ProfileHeader", "ProfilePicturePath", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "5aac903e-2767-4a58-a95b-6173999e08b5", null, "caseScally@gmail.com", true, "Case", "Scally", false, null, "ADMIN@ADMIN.COM", "CASESCALLY@GMAIL.COM", "AQAAAAEAACcQAAAAEDGrqRVI7nvRK1t8+78fUYunKbgrd9Hrxtkhxpo7wjvG5PS4y8R7LAz337zDCoSgGA==", null, false, null, null, null, "7f434309-a4d9-48e9-9ebb-8803db794577", "123 Infinity Way", false, "caseScally@gmail.com" },
                    { "e4356622-ec1e-4b02-b5b9-762e4916c2ff", 0, "09c292a4-217e-436a-99f7-3c049d79d1b7", null, "caseScally@gmail.com", true, "Molly", "Scally", false, null, "MOSCALLY@GMAIL.COM", "MOSCALLY@GMAIL.COM", "AQAAAAEAACcQAAAAEHBQo5+G5rDpGZ0iSxz7LVvMWsuIcI9MYBMs8voUDxPQ+0WmnofnyPP/8uUNc972CA==", null, false, null, null, null, "7f434309-a4d9-48e9-9ebb-8803db794578", "123 Infinity Way", false, "moScally@gmail.com" },
                    { "f5d1aaa8-b80a-4649-bea7-bbc0226c9866", 0, "e3123dfa-a70f-4bf4-9895-7d8b5c3c1f02", null, "hunter@gmail.com", true, "Hunter", "K", false, null, "HUNTER@GMAIL.COM", "HUNTER@GMAIL.COM", "AQAAAAEAACcQAAAAEEXcQLdm1Hsbp+17Mdc0dJgGW8a4LeCB/QJTnPGBuPZD9a2ChNjsAcDoHgl4KY+PBQ==", null, false, null, null, null, "7f434309-a4d9-48e9-9ebb-8803db794579", "249 Brentwood Place", false, "hunter@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "ApplicationUserId", "Name", "UserId" },
                values: new object[] { 1, null, "Cars in my driveway", "1" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AdminUserId", "Date", "Description", "ImagePath", "Location", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 5, 11, 10, 4, 13, 136, DateTimeKind.Local).AddTicks(8724), "Casual meet", "SomeTestUrl", "Church Street", "Cars and Coffee", "1" },
                    { 2, null, new DateTime(2020, 5, 11, 10, 4, 13, 137, DateTimeKind.Local).AddTicks(6999), "Imports only", "SomeOtherTestUrl", "Atlanta", "Import Alliance", "3" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "VehicleTypeName" },
                values: new object[,]
                {
                    { 14, "Van" },
                    { 13, "Station Wagon" },
                    { 12, "Crossover" },
                    { 11, "Subcompact Car" },
                    { 10, "Compact Car" },
                    { 9, "Convertible" },
                    { 8, "Minivan" },
                    { 5, "Truck" },
                    { 6, "Hatchback" },
                    { 15, "Motorcycle" },
                    { 4, "Sedan" },
                    { 3, "Sport Utility Vehicle" },
                    { 2, "Utility Vehicle" },
                    { 1, "Sports Car" },
                    { 7, "Coupe" },
                    { 16, "Supercar" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "CarDescription", "CarPageCoverUrl", "Make", "Model", "Name", "Url", "VehicleTypeId", "Year" },
                values: new object[] { 1, "00000000-ffff-ffff-ffff-ffffffffffff", "My car", "testUrl", "Infiniti", "G37", "G", 1, 1, 2012 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "CarDescription", "CarPageCoverUrl", "Make", "Model", "Name", "Url", "VehicleTypeId", "Year" },
                values: new object[] { 2, "e4356622-ec1e-4b02-b5b9-762e4916c2ff", "Molly's Car", "testUrl2", "Infiniti", "G37", "Genisis", 2, 1, 2009 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ApplicationUserId", "CarDescription", "CarPageCoverUrl", "Make", "Model", "Name", "Url", "VehicleTypeId", "Year" },
                values: new object[] { 3, "f5d1aaa8-b80a-4649-bea7-bbc0226c9866", "Hunterz car", "testUrl3", "Lexus", "IS250", "Lex", 3, 1, 2007 });

            migrationBuilder.InsertData(
                table: "LikedCars",
                columns: new[] { "Id", "CarId", "UserId", "UserId1" },
                values: new object[] { 1, 3, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ApplicationUserId",
                table: "Cars",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VehicleTypeId",
                table: "Cars",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_ApplicationUserId",
                table: "Collections",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AdminUserId",
                table: "Events",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedCars_CarId",
                table: "LikedCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedCars_UserId1",
                table: "LikedCars",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImages");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "LikedCars");

            migrationBuilder.DropTable(
                name: "ApplicationUserViewModel");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileBackgroundPicturePath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileHeader",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "AspNetUsers");
        }
    }
}
