using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paxa.Migrations
{
    public partial class Booking2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_user_HostId",
                table: "booking");

            migrationBuilder.DeleteData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<int>(
                name: "HostId",
                table: "booking",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HostId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HostId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 0, 34, 32, 788, DateTimeKind.Local).AddTicks(4220), new DateTime(2021, 3, 4, 1, 34, 32, 797, DateTimeKind.Local).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 1, 34, 32, 797, DateTimeKind.Local).AddTicks(8600), new DateTime(2021, 3, 4, 2, 34, 32, 797, DateTimeKind.Local).AddTicks(8600) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 2, 34, 32, 797, DateTimeKind.Local).AddTicks(8610), new DateTime(2021, 3, 4, 3, 34, 32, 797, DateTimeKind.Local).AddTicks(8610) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 3, 34, 32, 797, DateTimeKind.Local).AddTicks(8610), new DateTime(2021, 3, 4, 4, 34, 32, 797, DateTimeKind.Local).AddTicks(8610) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 4, 34, 32, 797, DateTimeKind.Local).AddTicks(8610), new DateTime(2021, 3, 4, 5, 34, 32, 797, DateTimeKind.Local).AddTicks(8610) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 5, 34, 32, 797, DateTimeKind.Local).AddTicks(8620), new DateTime(2021, 3, 4, 6, 34, 32, 797, DateTimeKind.Local).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 6, 34, 32, 797, DateTimeKind.Local).AddTicks(8620), new DateTime(2021, 3, 4, 7, 34, 32, 797, DateTimeKind.Local).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 7, 34, 32, 797, DateTimeKind.Local).AddTicks(8620), new DateTime(2021, 3, 4, 8, 34, 32, 797, DateTimeKind.Local).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 8, 34, 32, 797, DateTimeKind.Local).AddTicks(8620), new DateTime(2021, 3, 4, 9, 34, 32, 797, DateTimeKind.Local).AddTicks(8630) });

            migrationBuilder.AddForeignKey(
                name: "FK_booking_user_HostId",
                table: "booking",
                column: "HostId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_user_HostId",
                table: "booking");

            migrationBuilder.AlterColumn<int>(
                name: "HostId",
                table: "booking",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HostId",
                value: null);

            migrationBuilder.UpdateData(
                table: "booking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HostId",
                value: null);

            migrationBuilder.InsertData(
                table: "booking",
                columns: new[] { "Id", "HostId", "TimeslotId" },
                values: new object[,]
                {
                    { 9, null, 9 },
                    { 8, null, 8 },
                    { 3, null, 3 },
                    { 6, null, 6 },
                    { 5, null, 5 },
                    { 4, null, 4 },
                    { 7, null, 7 }
                });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 0, 27, 23, 22, DateTimeKind.Local).AddTicks(8010), new DateTime(2021, 3, 4, 1, 27, 23, 32, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 1, 27, 23, 32, DateTimeKind.Local).AddTicks(6690), new DateTime(2021, 3, 4, 2, 27, 23, 32, DateTimeKind.Local).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 2, 27, 23, 32, DateTimeKind.Local).AddTicks(6700), new DateTime(2021, 3, 4, 3, 27, 23, 32, DateTimeKind.Local).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 3, 27, 23, 32, DateTimeKind.Local).AddTicks(6700), new DateTime(2021, 3, 4, 4, 27, 23, 32, DateTimeKind.Local).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 4, 27, 23, 32, DateTimeKind.Local).AddTicks(6700), new DateTime(2021, 3, 4, 5, 27, 23, 32, DateTimeKind.Local).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 5, 27, 23, 32, DateTimeKind.Local).AddTicks(6710), new DateTime(2021, 3, 4, 6, 27, 23, 32, DateTimeKind.Local).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 6, 27, 23, 32, DateTimeKind.Local).AddTicks(6710), new DateTime(2021, 3, 4, 7, 27, 23, 32, DateTimeKind.Local).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 7, 27, 23, 32, DateTimeKind.Local).AddTicks(6710), new DateTime(2021, 3, 4, 8, 27, 23, 32, DateTimeKind.Local).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 8, 27, 23, 32, DateTimeKind.Local).AddTicks(6720), new DateTime(2021, 3, 4, 9, 27, 23, 32, DateTimeKind.Local).AddTicks(6720) });

            migrationBuilder.AddForeignKey(
                name: "FK_booking_user_HostId",
                table: "booking",
                column: "HostId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
