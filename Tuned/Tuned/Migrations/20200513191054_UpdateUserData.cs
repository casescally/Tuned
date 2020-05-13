using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class UpdateUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedCars_AspNetUsers_UserId",
                table: "LikedCars");

            migrationBuilder.DeleteData(
                table: "LikedCars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ca94d569-f3e4-452b-80e8-820d19eeeb1f", "CASESCALLY@GMAIL.COM", "AQAAAAEAACcQAAAAEKqYKVI0ka6vWdXlVlN7FZwlzTFj3BNFL75ALFltsRl1KWzP2K7bifN+/483C+dl8A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ee83d50c-3edb-45a1-abb6-44c0e110cc08", "moScally@gmail.com", "MOSCALLY@gmail.com", "AQAAAAEAACcQAAAAEA+MIYLTvJb0CTKzwpU0qqd/YyR5lTK8Aly5NO7yjsyw42Uwcd9kcpstTDo+lKTMrg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "333ce7d7-4440-45d0-83e9-9feb4896dec3", "AQAAAAEAACcQAAAAEFFwAhcQzALlqQsHTCnd+Qr4HkzO7Psns1Uxl2H0Jx+aTNRv1K3XBr3OqiBOV5lNww==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 13, 12, 10, 54, 144, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 13, 12, 10, 54, 144, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.AddForeignKey(
                name: "FK_LikedCars_ApplicationUserViewModel_UserId",
                table: "LikedCars",
                column: "UserId",
                principalTable: "ApplicationUserViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedCars_ApplicationUserViewModel_UserId",
                table: "LikedCars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "6b8398c2-d5f5-4f2d-b912-772a3ece62c6", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDCgIKa+XyVsTU4lKvRtcCW7ilaMtDn8UFpuWf85OV0cNcuq827c25VyX86k5mYg9g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "eb4f0d50-2693-4a0c-8fee-dd2f85a1dc15", "caseScally@gmail.com", "MOSCALLY@GMAIL.COM", "AQAAAAEAACcQAAAAEJi3Ne4FFNBdDesYRxO9f6BZy2yDM33/SMkhq89hT6+bGo3Ownh2ocATy2iRb4GQrA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6daeb79c-ab61-4b71-8b74-9037602bc6ca", "AQAAAAEAACcQAAAAEKW9Z6od+YjfT/qe8GClgB2NrrgpWwbaD+h4LlzBWS14YzWzV3hy8ael9GGRu3CUAQ==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 12, 15, 36, 42, 331, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 12, 15, 36, 42, 332, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.InsertData(
                table: "LikedCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[] { 1, 3, "00000000-ffff-ffff-ffff-ffffffffffff" });

            migrationBuilder.AddForeignKey(
                name: "FK_LikedCars_AspNetUsers_UserId",
                table: "LikedCars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
