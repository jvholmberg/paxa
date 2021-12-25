using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paxa.Migrations
{
    public partial class LocationOptionalForOrganizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_organization_location_LocationId",
                table: "organization");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "organization",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 25, 23, 51, 47, 227, DateTimeKind.Local).AddTicks(4980), new DateTime(2021, 12, 26, 0, 51, 47, 237, DateTimeKind.Local).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 26, 0, 51, 47, 237, DateTimeKind.Local).AddTicks(3870), new DateTime(2021, 12, 26, 1, 51, 47, 237, DateTimeKind.Local).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 26, 1, 51, 47, 237, DateTimeKind.Local).AddTicks(3880), new DateTime(2021, 12, 26, 2, 51, 47, 237, DateTimeKind.Local).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 26, 2, 51, 47, 237, DateTimeKind.Local).AddTicks(3880), new DateTime(2021, 12, 26, 3, 51, 47, 237, DateTimeKind.Local).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 26, 3, 51, 47, 237, DateTimeKind.Local).AddTicks(3880), new DateTime(2021, 12, 26, 4, 51, 47, 237, DateTimeKind.Local).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 26, 4, 51, 47, 237, DateTimeKind.Local).AddTicks(3890), new DateTime(2021, 12, 26, 5, 51, 47, 237, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 26, 5, 51, 47, 237, DateTimeKind.Local).AddTicks(3890), new DateTime(2021, 12, 26, 6, 51, 47, 237, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 26, 6, 51, 47, 237, DateTimeKind.Local).AddTicks(3890), new DateTime(2021, 12, 26, 7, 51, 47, 237, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 26, 7, 51, 47, 237, DateTimeKind.Local).AddTicks(3900), new DateTime(2021, 12, 26, 8, 51, 47, 237, DateTimeKind.Local).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$aQp0Sdfz9TQXHabPPSyove7xA1hG9DfLxgNQ7Zgg/FRnBO1D1RF7.");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$ZhzU.iHqF.oLxz4vyqMi7.jSRLHIREQBhoECDvrHSN7ccsohqSDAy");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$sCAjhFfwaxq3xQTweRZWZeXvjDMfiyipeQCRHIAzYeCSiC6zt1PaC");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$2mmYcZqHsKdmbsszrS.ok.lzDIvrzBWWe5KUxgHnCT9iTlcNaH59.");

            migrationBuilder.AddForeignKey(
                name: "FK_organization_location_LocationId",
                table: "organization",
                column: "LocationId",
                principalTable: "location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_organization_location_LocationId",
                table: "organization");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "organization",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_organization_location_LocationId",
                table: "organization",
                column: "LocationId",
                principalTable: "location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
