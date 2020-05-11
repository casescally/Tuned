using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class Active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActiveEvent",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveCollection",
                table: "Collections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveCar",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveUser",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveEvent",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ActiveCollection",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "ActiveCar",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ActiveUser",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11555deb-e735-4eee-8f50-a14b3cfcda5e", "AQAAAAEAACcQAAAAEAUD8/zfFFU02MZ7SN+c4uhzpGbpAPmBpcoEEn1yJ63huVC+BzGVlhQxIR2Ch6Ud7Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43b694ff-b9ee-4631-8745-1a2a152eeb09", "AQAAAAEAACcQAAAAENuq0Tdct38L+pheE4aopqWQMzFXcH5rQqE8HjzXyizBiXEDsqpss4Q3U2gytso+UA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5e95ed2-3917-422d-90f9-c9673e2bc476", "AQAAAAEAACcQAAAAEMwKHdKCynd4weGA7ZL6NCb9GOzlkWRj6EfFywVme+Ln1Tpt88zi3FUYgZ/E8Y8NSw==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 11, 14, 41, 11, 819, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 11, 14, 41, 11, 820, DateTimeKind.Local).AddTicks(8705));
        }
    }
}
