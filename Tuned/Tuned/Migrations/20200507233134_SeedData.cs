using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileBackgroundPicturePath", "ProfileHeader", "ProfilePicturePath", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "f4b567cf-27bd-4abb-9eed-a3a1cc67871c", null, "caseScally@gmail.com", true, "Case", "Scally", false, null, "ADMIN@ADMIN.COM", "CASESCALLY@CASESCALLY.COM", "AQAAAAEAACcQAAAAEGgzMvcZh67pSWJHF87CTHZ9HeGTHpv7VIGI0ttrOXx5awt/F+EODLE1Ssa9Rnjrrg==", null, false, null, null, null, "7f434309-a4d9-48e9-9ebb-8803db794577", "123 Infinity Way", false, "caseScally@gmail.com" });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "VehicleTypeName" },
                values: new object[] { 1, "Sports Car" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "ApplicationUserId", "CarDescription", "CarPageCoverUrl", "Make", "Model", "Name", "Url", "VehicleTypeId", "Year" },
                values: new object[] { 1, "00000000-ffff-ffff-ffff-ffffffffffff", "My car", "testUrl", "Infiniti", "G37", "G", 1, 1, 2012 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
