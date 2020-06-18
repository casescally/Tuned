using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuned.Migrations
{
    public partial class UserEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserEvent",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_ApplicationUserId",
                table: "UserEvent",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_EventId",
                table: "UserEvent",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_ApplicationUserViewModel_ApplicationUserId",
                table: "UserEvent",
                column: "ApplicationUserId",
                principalTable: "ApplicationUserViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_ApplicationUserViewModel_ApplicationUserId",
                table: "UserEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Events_EventId",
                table: "UserEvent");

            migrationBuilder.DropIndex(
                name: "IX_UserEvent_ApplicationUserId",
                table: "UserEvent");

            migrationBuilder.DropIndex(
                name: "IX_UserEvent_EventId",
                table: "UserEvent");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserEvent");

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
    }
}
