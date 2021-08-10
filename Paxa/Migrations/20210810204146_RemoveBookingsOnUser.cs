using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paxa.Migrations
{
    public partial class RemoveBookingsOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 10, 22, 41, 44, 592, DateTimeKind.Local).AddTicks(9850), new DateTime(2021, 8, 10, 23, 41, 44, 608, DateTimeKind.Local).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 10, 23, 41, 44, 608, DateTimeKind.Local).AddTicks(2440), new DateTime(2021, 8, 11, 0, 41, 44, 608, DateTimeKind.Local).AddTicks(2450) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 11, 0, 41, 44, 608, DateTimeKind.Local).AddTicks(2460), new DateTime(2021, 8, 11, 1, 41, 44, 608, DateTimeKind.Local).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 11, 1, 41, 44, 608, DateTimeKind.Local).AddTicks(2470), new DateTime(2021, 8, 11, 2, 41, 44, 608, DateTimeKind.Local).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 11, 2, 41, 44, 608, DateTimeKind.Local).AddTicks(2480), new DateTime(2021, 8, 11, 3, 41, 44, 608, DateTimeKind.Local).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 11, 3, 41, 44, 608, DateTimeKind.Local).AddTicks(2490), new DateTime(2021, 8, 11, 4, 41, 44, 608, DateTimeKind.Local).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 11, 4, 41, 44, 608, DateTimeKind.Local).AddTicks(2500), new DateTime(2021, 8, 11, 5, 41, 44, 608, DateTimeKind.Local).AddTicks(2500) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 11, 5, 41, 44, 608, DateTimeKind.Local).AddTicks(2510), new DateTime(2021, 8, 11, 6, 41, 44, 608, DateTimeKind.Local).AddTicks(2510) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 8, 11, 6, 41, 44, 608, DateTimeKind.Local).AddTicks(2510), new DateTime(2021, 8, 11, 7, 41, 44, 608, DateTimeKind.Local).AddTicks(2520) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$MWLhRydXZU9c/GBQodUAYeM/WbMcweq9ydGAQaUhMU4KPGsgQuYcG");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$HZHLFaoAvW7gGTKj8jRuUO4DWyk/xaDsdeTfx0TZ8Cr6q5AwwQSD6");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$7U6D7YJms.JGSFY.cHVj0eqQvvsH84RGAJzIa9.ITiYlcPzSh08vW");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$6aCtspFG1YjEJTuVSgGS.uPGHRIRN96zzKOLml69w5Ui1e5GYOb2C");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 30, 17, 27, 31, 347, DateTimeKind.Local).AddTicks(4310), new DateTime(2021, 7, 30, 18, 27, 31, 357, DateTimeKind.Local).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 30, 18, 27, 31, 357, DateTimeKind.Local).AddTicks(3110), new DateTime(2021, 7, 30, 19, 27, 31, 357, DateTimeKind.Local).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 30, 19, 27, 31, 357, DateTimeKind.Local).AddTicks(3130), new DateTime(2021, 7, 30, 20, 27, 31, 357, DateTimeKind.Local).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 30, 20, 27, 31, 357, DateTimeKind.Local).AddTicks(3130), new DateTime(2021, 7, 30, 21, 27, 31, 357, DateTimeKind.Local).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 30, 21, 27, 31, 357, DateTimeKind.Local).AddTicks(3140), new DateTime(2021, 7, 30, 22, 27, 31, 357, DateTimeKind.Local).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 30, 22, 27, 31, 357, DateTimeKind.Local).AddTicks(3140), new DateTime(2021, 7, 30, 23, 27, 31, 357, DateTimeKind.Local).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 30, 23, 27, 31, 357, DateTimeKind.Local).AddTicks(3150), new DateTime(2021, 7, 31, 0, 27, 31, 357, DateTimeKind.Local).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 31, 0, 27, 31, 357, DateTimeKind.Local).AddTicks(3150), new DateTime(2021, 7, 31, 1, 27, 31, 357, DateTimeKind.Local).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 7, 31, 1, 27, 31, 357, DateTimeKind.Local).AddTicks(3160), new DateTime(2021, 7, 31, 2, 27, 31, 357, DateTimeKind.Local).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$V3AzBqwil4k6X72g9ONQn.7nLP1H1MNnCNVBCD1t/xvc.A5muDZVu");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$a.5iKvQwji..o8XsuDYS1.nWGTVr/Hysx1v6ka4AbOYIjZbAc07LC");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$QLY4VNs89Pn14D3rOzDBiOcltjiW/azVknbYMfuXK/dcR2ocfH79m");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$JIsRYflMzQ7/PhIyAoFe1.LVhfYBD6poS9v7ncUSfr3RZc9hRO5.u");
        }
    }
}
