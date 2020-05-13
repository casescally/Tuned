using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class UserEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ApplicationUserViewModel_AdminUserId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "ApplicationUserViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Events_AdminUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AdminUserId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "UserEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvent", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42a4620d-fc3b-4326-bc1e-88f66a9cd388", "AQAAAAEAACcQAAAAENVTL2ig48njeJj/eGF7WtTfr+eUaQhGDwTtDIWeaSv7yPzUpXGjkvvZR4qIgnIj6g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "535c7951-d07f-4605-b5c6-4c25a13d4a72", "AQAAAAEAACcQAAAAEChdTTlXvYuvAQtJWaPjq1h+4yRG6Pb6hiWfb/83ChFN5uXpqXQXv9UmSRcb3F1Jnw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84a8fa7f-85e5-4476-99b2-3b07cc8abad1", "AQAAAAEAACcQAAAAEEAdUvhHxmpHTGAcUWdC0rEGTzfcD9BHGqMJ5nSdeC71sXV68qSaVe618SQX+Wocdg==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 11, 14, 6, 27, 858, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 11, 14, 6, 27, 859, DateTimeKind.Local).AddTicks(1043));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvent");

            migrationBuilder.AddColumn<string>(
                name: "AdminUserId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserViewModel", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5aac903e-2767-4a58-a95b-6173999e08b5", "AQAAAAEAACcQAAAAEDGrqRVI7nvRK1t8+78fUYunKbgrd9Hrxtkhxpo7wjvG5PS4y8R7LAz337zDCoSgGA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09c292a4-217e-436a-99f7-3c049d79d1b7", "AQAAAAEAACcQAAAAEHBQo5+G5rDpGZ0iSxz7LVvMWsuIcI9MYBMs8voUDxPQ+0WmnofnyPP/8uUNc972CA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3123dfa-a70f-4bf4-9895-7d8b5c3c1f02", "AQAAAAEAACcQAAAAEEXcQLdm1Hsbp+17Mdc0dJgGW8a4LeCB/QJTnPGBuPZD9a2ChNjsAcDoHgl4KY+PBQ==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 11, 10, 4, 13, 136, DateTimeKind.Local).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 11, 10, 4, 13, 137, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.CreateIndex(
                name: "IX_Events_AdminUserId",
                table: "Events",
                column: "AdminUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ApplicationUserViewModel_AdminUserId",
                table: "Events",
                column: "AdminUserId",
                principalTable: "ApplicationUserViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
