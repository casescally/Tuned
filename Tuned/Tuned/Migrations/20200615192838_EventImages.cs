using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class EventImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ApplicationUserViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileBackgroundPicturePath",
                table: "ApplicationUserViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileHeader",
                table: "ApplicationUserViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "ApplicationUserViewModel",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc77cb29-fc59-4938-ad5a-5d6ac34c1f60", "AQAAAAEAACcQAAAAEIOaJ+voRi/8j2IrHI2LPP07fxo4x4lkSj9LLBEL8plHysVOvhbvDV5liLnMhPpQoA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "afa7818e-3fb8-4181-ac16-6099a7e1995b", "AQAAAAEAACcQAAAAEDUqhTE75pA+a59og4KLEvq0ZDP34nWzg+kYkGcDhv6U+WafUKRPdpnVMX11bQU5IQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4cb8abd-bfae-45cb-b55d-6658a16e8942", "AQAAAAEAACcQAAAAEO15vQccJO1MePO72Zov0026oakfmJD385/7aCsdm8eegoY7FUt14NL+7xXfC4AlQA==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 6, 15, 12, 28, 37, 724, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 6, 15, 12, 28, 37, 725, DateTimeKind.Local).AddTicks(7048));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ApplicationUserViewModel");

            migrationBuilder.DropColumn(
                name: "ProfileBackgroundPicturePath",
                table: "ApplicationUserViewModel");

            migrationBuilder.DropColumn(
                name: "ProfileHeader",
                table: "ApplicationUserViewModel");

            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "ApplicationUserViewModel");

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
    }
}
