using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Paxa.Migrations
{
    public partial class AddedRatingToPersonAndOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rating_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: true),
                    OrganizationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rating_organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rating_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rating_rating_type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "rating_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "rating_type",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "General" });

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

            migrationBuilder.InsertData(
                table: "rating",
                columns: new[] { "Id", "OrganizationId", "PersonId", "TypeId", "Value" },
                values: new object[] { 1, null, 2, 1, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_rating_OrganizationId",
                table: "rating",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_rating_PersonId",
                table: "rating",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_rating_TypeId",
                table: "rating",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "rating_type");

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 12, 22, 5, 8, 144, DateTimeKind.Local).AddTicks(9940), new DateTime(2021, 4, 12, 23, 5, 8, 155, DateTimeKind.Local).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 12, 23, 5, 8, 155, DateTimeKind.Local).AddTicks(1900), new DateTime(2021, 4, 13, 0, 5, 8, 155, DateTimeKind.Local).AddTicks(1920) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 13, 0, 5, 8, 155, DateTimeKind.Local).AddTicks(1920), new DateTime(2021, 4, 13, 1, 5, 8, 155, DateTimeKind.Local).AddTicks(1920) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 13, 1, 5, 8, 155, DateTimeKind.Local).AddTicks(1930), new DateTime(2021, 4, 13, 2, 5, 8, 155, DateTimeKind.Local).AddTicks(1930) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 13, 2, 5, 8, 155, DateTimeKind.Local).AddTicks(1930), new DateTime(2021, 4, 13, 3, 5, 8, 155, DateTimeKind.Local).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 13, 3, 5, 8, 155, DateTimeKind.Local).AddTicks(1940), new DateTime(2021, 4, 13, 4, 5, 8, 155, DateTimeKind.Local).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 13, 4, 5, 8, 155, DateTimeKind.Local).AddTicks(1940), new DateTime(2021, 4, 13, 5, 5, 8, 155, DateTimeKind.Local).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 13, 5, 5, 8, 155, DateTimeKind.Local).AddTicks(1950), new DateTime(2021, 4, 13, 6, 5, 8, 155, DateTimeKind.Local).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 4, 13, 6, 5, 8, 155, DateTimeKind.Local).AddTicks(1960), new DateTime(2021, 4, 13, 7, 5, 8, 155, DateTimeKind.Local).AddTicks(1960) });
        }
    }
}
