using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class CarImagesActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CarImages",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "CarImages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ca94d569-f3e4-452b-80e8-820d19eeeb1f", "AQAAAAEAACcQAAAAEKqYKVI0ka6vWdXlVlN7FZwlzTFj3BNFL75ALFltsRl1KWzP2K7bifN+/483C+dl8A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee83d50c-3edb-45a1-abb6-44c0e110cc08", "AQAAAAEAACcQAAAAEA+MIYLTvJb0CTKzwpU0qqd/YyR5lTK8Aly5NO7yjsyw42Uwcd9kcpstTDo+lKTMrg==" });

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
        }
    }
}
