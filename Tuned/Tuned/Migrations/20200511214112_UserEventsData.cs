using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class UserEventsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserEvent",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AdminUserId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
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

            migrationBuilder.UpdateData(
                table: "UserEvent",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.UpdateData(
                table: "UserEvent",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserEvent",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2cf224c6-f862-4332-830b-6eb79c676778", "AQAAAAEAACcQAAAAEF2YQx8wG56ujpJzUhIvEjaZcvWFFuWPcVLbBTWsLOPbYzmp5nBeVvYhF9KbXQRueg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4356622-ec1e-4b02-b5b9-762e4916c2ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17640f99-c211-4683-9fde-fb2b8d06d45d", "AQAAAAEAACcQAAAAEMwyDPqPJ3xNPAoyc457+5xSgYoOIYVNTP31UBqul6ablXQuB/zFe5gHVvHxkL4msQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d1aaa8-b80a-4649-bea7-bbc0226c9866",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4c0cb5b-f85f-4959-b257-43640e751de5", "AQAAAAEAACcQAAAAEI5/HGPOsqLhkD8tQS1RTKV01O4Hp3CP6SN1onek0kBbSqx0ZUlfgzTJHkHx/4bQjA==" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 5, 11, 14, 13, 16, 63, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 5, 11, 14, 13, 16, 63, DateTimeKind.Local).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "UserEvent",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "UserEvent",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 3);
        }
    }
}
