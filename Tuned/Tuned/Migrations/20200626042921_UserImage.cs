using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class UserImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b596e901-7c61-4b82-8cf8-8205792d5432", "AQAAAAEAACcQAAAAEO8LMsqQzo06hECQJwd9wiYgf9RreVBi70uTyFPFQJMnQwIEd5Gz1owsPm0I0L6Dpg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f0fda7f-728a-4e43-8c3f-2403281dc26f", "AQAAAAEAACcQAAAAECfkXvYffbK1C629zs0+JkITmEozJVxY+HWH2eClN0f2rchwAE6cQpvIQ8lZdh/3Uw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57c0d40c-7863-4380-a6ff-622961e5f8c6", "AQAAAAEAACcQAAAAEIcR0VK62RsdjagF/99jIHWFgdjEx5f5AYHvnGFQaGGOJY4eULJUTaVsMEHqhM1eqQ==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 6, 25, 21, 29, 20, 620, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 6, 25, 21, 29, 20, 621, DateTimeKind.Local).AddTicks(6877));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67c84fae-9354-43aa-b6da-bd49bebe7b83", "AQAAAAEAACcQAAAAECU3JCd7hMmcosZMrjq2VtfLnRXvUeJicRhuZ1mgVtBrI08Oxm8yr/Y6oJE2pbS3dg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4344efe-517b-44e4-950d-3edb345cc32b", "AQAAAAEAACcQAAAAEAzDt9W3jHHB3sx/rap6qETRBr9w+lkxTWiWk32Cq3HxaBNXFhUjbrETInMQnlGVdA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a26ad720-837f-443c-8a11-974223b3ae5a", "AQAAAAEAACcQAAAAELvm65yTods419jU9VsBsf8uGkhWUKBjgztcvKoMAs/PcziAu2Zi8L2CcU86XhX3ew==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 6, 17, 10, 44, 35, 693, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 6, 17, 10, 44, 35, 694, DateTimeKind.Local).AddTicks(4312));
        }
    }
}
