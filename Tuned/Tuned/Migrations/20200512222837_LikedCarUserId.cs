using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class LikedCarUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedCars_AspNetUsers_UserId1",
                table: "LikedCars");

            migrationBuilder.DropIndex(
                name: "IX_LikedCars_UserId1",
                table: "LikedCars");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "LikedCars");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LikedCars",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_LikedCars_UserId",
                table: "LikedCars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedCars_AspNetUsers_UserId",
                table: "LikedCars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedCars_AspNetUsers_UserId",
                table: "LikedCars");

            migrationBuilder.DropIndex(
                name: "IX_LikedCars_UserId",
                table: "LikedCars");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LikedCars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "LikedCars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "858cae32-04ce-4cbd-8164-92000d4befc9", "AQAAAAEAACcQAAAAENnK9y4JtQKop8hlCeQPZHV8r6nyOR6klQE1YoVDOYBX5R039hkX81Kla5Uv6/GYzQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c38c9ac8-7b60-4c12-8c3f-787e6037207d", "AQAAAAEAACcQAAAAEFvmfZZ/VVyrNcL38fEqey2cL5ImckKC//wU6mD8/sUUUqujmcAsg71ttQ216fCQ8Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dddebab4-99c5-4bac-aef2-94b826083c8b", "AQAAAAEAACcQAAAAENh8FIS4gU2gq/hcp+oNlLkz0hxtw8qGPK3YZiS3D2oE7vtemPy0zpGowjyuXyouRw==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 11, 15, 59, 19, 769, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 11, 15, 59, 19, 770, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "LikedCars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_LikedCars_UserId1",
                table: "LikedCars",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedCars_AspNetUsers_UserId1",
                table: "LikedCars",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
