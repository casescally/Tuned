using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class UpdateLikedCarAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedCars_ApplicationUserViewModel_UserId",
                table: "LikedCars");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "ApplicationUserViewModel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1401784-a04f-4294-a9fa-c347cd58a727", "AQAAAAEAACcQAAAAEBVACrkgMWpX4o6KqW33I7LakBgwq97gebYMSNQwDj3i/Eh36Jey6nwYOku2c51SIw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67d8855d-3a35-46bb-8fee-9200823287cc", "AQAAAAEAACcQAAAAEMUuk3JrBwamYcCytLRFeKaBpEo90jLT9Tt1Gw8wcFTMbpmY0yGYTSl51IG4BIb2eg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8253c717-f4cb-417b-a83a-ebd09aa0511c", "AQAAAAEAACcQAAAAECMVrhhPNfcWEgAmKHpWUZbCcCTBx1jpivw/mJeGn87I8aIitiwY30P0sIrQyU/Lrg==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 18, 16, 40, 12, 554, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 18, 16, 40, 12, 555, DateTimeKind.Local).AddTicks(7876));

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

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ApplicationUserViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11e03fc4-9ed6-4aae-9b76-c7ec0de6bc51", "AQAAAAEAACcQAAAAEOmj1q+OsGRmVHnzYxH5BXn1bdtx+2R7IsLeYBm4rgOfd5IphotDy8hZMa/B/f4t2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04aaed32-b3e7-46cc-8484-7ca783b7b8cd", "AQAAAAEAACcQAAAAEEsvBGd47BmQCIrMvfWfapmLZRrtnKLnTQee2o27M1OSXRfwGFgUNiQjDx8QF2hKIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae5c1eb2-908f-4496-8809-57a5dd5c7261", "AQAAAAEAACcQAAAAEP0Gqpr13bw+ffGcUAUDjfeD8YNRt7TG+NRCb4YzBsMYZ1FRaabaDz81XAWWcMesNg==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 14, 20, 1, 50, 523, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 14, 20, 1, 50, 524, DateTimeKind.Local).AddTicks(9867));

            migrationBuilder.AddForeignKey(
                name: "FK_LikedCars_ApplicationUserViewModel_UserId",
                table: "LikedCars",
                column: "UserId",
                principalTable: "ApplicationUserViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
