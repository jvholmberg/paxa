using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paxa.Data.Migrations
{
    public partial class RefreshToken_RevokedByIP_allow_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RevokedByIp",
                table: "RefreshTokens",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ReplacedByToken",
                table: "RefreshTokens",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonRevoked",
                table: "RefreshTokens",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 13, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 14, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 15, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 15, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 16, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 16, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 17, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 17, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 18, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 18, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 19, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 19, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 20, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 20, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 21, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 21, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880), new DateTime(2022, 2, 2, 22, 47, 7, 645, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$5GToeS4a1xdzynTj2fpBR.0.Aemg6t0j9YgNAs32WxJtKbo0U7PYu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$tz6wl2SCjavInvkaUO/qquHQFRD6BdIKN.imgPA4BhImqW29WkX0e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$LuzzsjXZu7CMUgkzs.nKO.7pllBB8p/4c0V8iNitZXEdLYIRa8gVO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$QkrHFx/01kCSVj/NOZfrq.PTF2Ycuow3tv05VsJxIdDpjvbe090t6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RevokedByIp",
                table: "RefreshTokens",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReplacedByToken",
                table: "RefreshTokens",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReasonRevoked",
                table: "RefreshTokens",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 13, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 14, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 15, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 15, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 16, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 16, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 17, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 17, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 18, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 18, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 19, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 19, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 20, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 20, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 21, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2022, 2, 2, 21, 34, 51, 169, DateTimeKind.Utc).AddTicks(800), new DateTime(2022, 2, 2, 22, 34, 51, 169, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$TOjMWknFvCw9wV8YVbaz1eaj5yziQZS0GvFlFLsWJdaVOwzwEQ8IG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$fOw5tXIyc2K0ntbJuH.1uuVe6ywsMhlYzdpW3z8ugDQlIjoy8Ezeq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$qzmFCNlIPg7y2yCEzz/Xu.fOJ.CAlXWa6plX2HslaMhvvXfhpLEbW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$CQQV8GbxPjqg3t8tKS2rM.rf5r6uoPXDtx/sxr7i4WXff602sH9oO");
        }
    }
}
