using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class SeedLikedCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b8398c2-d5f5-4f2d-b912-772a3ece62c6", "AQAAAAEAACcQAAAAEDCgIKa+XyVsTU4lKvRtcCW7ilaMtDn8UFpuWf85OV0cNcuq827c25VyX86k5mYg9g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb4f0d50-2693-4a0c-8fee-dd2f85a1dc15", "AQAAAAEAACcQAAAAEJi3Ne4FFNBdDesYRxO9f6BZy2yDM33/SMkhq89hT6+bGo3Ownh2ocATy2iRb4GQrA==" });

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

            migrationBuilder.UpdateData(
                table: "LikedCars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "00000000-ffff-ffff-ffff-ffffffffffff");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "213d8e39-1859-466f-8ccd-0bc587d71e9a", "AQAAAAEAACcQAAAAEP9DfPtwTHIuTaUP24tJCNXs+MznIQR2fxOG7zxh1n1d0JopfKY/flpWBahhwYR0QA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e519678-f2ff-423f-bf6b-db66a07556b1", "AQAAAAEAACcQAAAAEKV9HnZFf2c6Ve+bEJlvzcKlJJRRdOcTtLNRZRDgWmwOtt1RUaokmxSg7oJM8Fk6Lw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8443ab12-1790-42a8-aa28-bf03d4f0e002", "AQAAAAEAACcQAAAAEOV9Uc5w7TsTk/U/yJ7EZ1b23VW5Z3ZNB6j9dnkBO/A2GlMBEPKzRgUudb7geg9N6w==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 12, 15, 28, 37, 123, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 12, 15, 28, 37, 124, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "LikedCars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "1");
        }
    }
}
