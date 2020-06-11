using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class CarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Cars");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Url",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "76bc905a-db4b-4553-a0ff-01ef73d170ee", "AQAAAAEAACcQAAAAEGb71ErkGzC6GfKmOo6UB8+sg/zxyZBZvSkNMWmVPra/57puLz0c0L4inPd85g6R9w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "070d676c-46ff-491b-8530-1ee3418385e1", "AQAAAAEAACcQAAAAEFMqNq2KEz53f8lshIWDzhD8YHAbdkHgciliOGbuegurQBRS0/IqMI4lQqOWWSf/6w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e05706f-5165-47c3-9409-d8eddc830de1", "AQAAAAEAACcQAAAAEMuTeQrpj4ram8KhevFQRMvHnDq6jFaeiKMqSQLoZfmrEsW7dqta9cSmCNTTG/zSTg==" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 14, 10, 45, 6, 150, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 14, 10, 45, 6, 151, DateTimeKind.Local).AddTicks(2466));
        }
    }
}
