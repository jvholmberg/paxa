using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Paxa.Migrations
{
    public partial class AddAddressToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "person",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "person",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Älmhult", "Sweden", "34391", "Femlingehult 2384" },
                    { 2, "Älmhult", "Sweden", "34391", "Femlingehult 2384" }
                });

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

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddressId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "person",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddressId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_person_AddressId",
                table: "person",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_Address_AddressId",
                table: "person",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_Address_AddressId",
                table: "person");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_person_AddressId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "person");

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 17, 20, 5, 18, 540, DateTimeKind.Local).AddTicks(9760), new DateTime(2021, 3, 17, 21, 5, 18, 551, DateTimeKind.Local).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 17, 21, 5, 18, 551, DateTimeKind.Local).AddTicks(4210), new DateTime(2021, 3, 17, 22, 5, 18, 551, DateTimeKind.Local).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 17, 22, 5, 18, 551, DateTimeKind.Local).AddTicks(4220), new DateTime(2021, 3, 17, 23, 5, 18, 551, DateTimeKind.Local).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 17, 23, 5, 18, 551, DateTimeKind.Local).AddTicks(4220), new DateTime(2021, 3, 18, 0, 5, 18, 551, DateTimeKind.Local).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 18, 0, 5, 18, 551, DateTimeKind.Local).AddTicks(4230), new DateTime(2021, 3, 18, 1, 5, 18, 551, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 18, 1, 5, 18, 551, DateTimeKind.Local).AddTicks(4230), new DateTime(2021, 3, 18, 2, 5, 18, 551, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 18, 2, 5, 18, 551, DateTimeKind.Local).AddTicks(4230), new DateTime(2021, 3, 18, 3, 5, 18, 551, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 18, 3, 5, 18, 551, DateTimeKind.Local).AddTicks(4240), new DateTime(2021, 3, 18, 4, 5, 18, 551, DateTimeKind.Local).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "timeslot",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 3, 18, 4, 5, 18, 551, DateTimeKind.Local).AddTicks(4240), new DateTime(2021, 3, 18, 5, 5, 18, 551, DateTimeKind.Local).AddTicks(4240) });
        }
    }
}
