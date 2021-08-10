using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Paxa.Migrations
{
    public partial class JwtTokenAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "user",
                newName: "PasswordHash");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Expires = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: true),
                    Revoked = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "user",
                newName: "Password");

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 14, 4, 6, 831, DateTimeKind.Local).AddTicks(5110), new DateTime(2021, 6, 4, 15, 4, 6, 844, DateTimeKind.Local).AddTicks(2100) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 15, 4, 6, 844, DateTimeKind.Local).AddTicks(2700), new DateTime(2021, 6, 4, 16, 4, 6, 844, DateTimeKind.Local).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 16, 4, 6, 844, DateTimeKind.Local).AddTicks(2720), new DateTime(2021, 6, 4, 17, 4, 6, 844, DateTimeKind.Local).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 17, 4, 6, 844, DateTimeKind.Local).AddTicks(2730), new DateTime(2021, 6, 4, 18, 4, 6, 844, DateTimeKind.Local).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 18, 4, 6, 844, DateTimeKind.Local).AddTicks(2860), new DateTime(2021, 6, 4, 19, 4, 6, 844, DateTimeKind.Local).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 19, 4, 6, 844, DateTimeKind.Local).AddTicks(2870), new DateTime(2021, 6, 4, 20, 4, 6, 844, DateTimeKind.Local).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 20, 4, 6, 844, DateTimeKind.Local).AddTicks(2870), new DateTime(2021, 6, 4, 21, 4, 6, 844, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 21, 4, 6, 844, DateTimeKind.Local).AddTicks(2880), new DateTime(2021, 6, 4, 22, 4, 6, 844, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 6, 4, 22, 4, 6, 844, DateTimeKind.Local).AddTicks(2890), new DateTime(2021, 6, 4, 23, 4, 6, 844, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: null);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: null);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: null);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: null);
        }
    }
}
