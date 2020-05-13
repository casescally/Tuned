using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class UserEventsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "UserEvent",
                columns: new[] { "Id", "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserEvent",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserEvent",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
