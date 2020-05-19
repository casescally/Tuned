using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class CarImageFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileNames",
                table: "Cars",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09c0cf5b-7e31-49db-94de-0063b1a4efd9", "AQAAAAEAACcQAAAAEITRQSC96+Dc85zDTxqazbLCIwbg3eTIfAcWwa9fV+6+HyE6CKjodZJUNRFiQglfPg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec86865f-a61a-4134-b8c0-d955835c5409", "AQAAAAEAACcQAAAAECAWCzaTxPp/uYpCz8lGOwBTg80QmM7vMMfWggPLOWZtdxAqax4o2l1iNoaoRZh0ig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac6d2e93-fb2a-4063-8570-fbece9c38964", "AQAAAAEAACcQAAAAEJ1xbtJruoSpPxfcyfDBR9enWV7/uCk6E7mRa4PVdPEMsi8+ZjprhsFsmWaBkI5w6g==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 19, 9, 23, 34, 737, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 19, 9, 23, 34, 738, DateTimeKind.Local).AddTicks(8410));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileNames",
                table: "Cars");

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
        }
    }
}
