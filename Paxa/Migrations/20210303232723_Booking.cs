using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paxa.Migrations
{
    public partial class Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_person_PersonId",
                table: "booking");

            migrationBuilder.DropForeignKey(
                name: "FK_user_booking_BookingId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_BookingId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "booking",
                newName: "HostId");

            migrationBuilder.RenameIndex(
                name: "IX_booking_PersonId",
                table: "booking",
                newName: "IX_booking_HostId");

            migrationBuilder.CreateTable(
                name: "BookingPerson",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "integer", nullable: false),
                    ParticipantsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingPerson", x => new { x.BookingsId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_BookingPerson_booking_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingPerson_person_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_BookingPerson_ParticipantsId",
                table: "BookingPerson",
                column: "ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_user_HostId",
                table: "booking",
                column: "HostId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_user_HostId",
                table: "booking");

            migrationBuilder.DropTable(
                name: "BookingPerson");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "booking",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_booking_HostId",
                table: "booking",
                newName: "IX_booking_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "user",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 0, 4, 11, 702, DateTimeKind.Local).AddTicks(3050), new DateTime(2021, 3, 4, 1, 4, 11, 711, DateTimeKind.Local).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 1, 4, 11, 711, DateTimeKind.Local).AddTicks(7770), new DateTime(2021, 3, 4, 2, 4, 11, 711, DateTimeKind.Local).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 2, 4, 11, 711, DateTimeKind.Local).AddTicks(7780), new DateTime(2021, 3, 4, 3, 4, 11, 711, DateTimeKind.Local).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 3, 4, 11, 711, DateTimeKind.Local).AddTicks(7790), new DateTime(2021, 3, 4, 4, 4, 11, 711, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 4, 4, 11, 711, DateTimeKind.Local).AddTicks(7790), new DateTime(2021, 3, 4, 5, 4, 11, 711, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 5, 4, 11, 711, DateTimeKind.Local).AddTicks(7790), new DateTime(2021, 3, 4, 6, 4, 11, 711, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 6, 4, 11, 711, DateTimeKind.Local).AddTicks(7790), new DateTime(2021, 3, 4, 7, 4, 11, 711, DateTimeKind.Local).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 7, 4, 11, 711, DateTimeKind.Local).AddTicks(7800), new DateTime(2021, 3, 4, 8, 4, 11, 711, DateTimeKind.Local).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 4, 8, 4, 11, 711, DateTimeKind.Local).AddTicks(7800), new DateTime(2021, 3, 4, 9, 4, 11, 711, DateTimeKind.Local).AddTicks(7800) });

            migrationBuilder.CreateIndex(
                name: "IX_user_BookingId",
                table: "user",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_person_PersonId",
                table: "booking",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_booking_BookingId",
                table: "user",
                column: "BookingId",
                principalTable: "booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
