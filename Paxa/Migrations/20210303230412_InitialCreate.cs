using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Paxa.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resource_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resource_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organization_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPerson",
                columns: table => new
                {
                    FollowersId = table.Column<int>(type: "integer", nullable: false),
                    FollowingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPerson", x => new { x.FollowersId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_PersonPerson_person_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPerson_person_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resource_organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resource_resource_type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "resource_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "timeslot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ResourceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timeslot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_timeslot_resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeslotId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_booking_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_booking_timeslot_TimeslotId",
                        column: x => x.TimeslotId,
                        principalTable: "timeslot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: true),
                    OrganizationId = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    BookingId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "location",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1, "0", "0" },
                    { 2, "99", "99" }
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Johan", "Holmberg" },
                    { 2, "Joel", "Holmberg" }
                });

            migrationBuilder.InsertData(
                table: "resource_type",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Description", "Padel" });

            migrationBuilder.InsertData(
                table: "timeslot",
                columns: new[] { "Id", "From", "ResourceId", "To" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 4, 0, 4, 11, 702, DateTimeKind.Local).AddTicks(3050), null, new DateTime(2021, 3, 4, 1, 4, 11, 711, DateTimeKind.Local).AddTicks(7250) },
                    { 2, new DateTime(2021, 3, 4, 1, 4, 11, 711, DateTimeKind.Local).AddTicks(7770), null, new DateTime(2021, 3, 4, 2, 4, 11, 711, DateTimeKind.Local).AddTicks(7780) },
                    { 3, new DateTime(2021, 3, 4, 2, 4, 11, 711, DateTimeKind.Local).AddTicks(7780), null, new DateTime(2021, 3, 4, 3, 4, 11, 711, DateTimeKind.Local).AddTicks(7780) },
                    { 4, new DateTime(2021, 3, 4, 3, 4, 11, 711, DateTimeKind.Local).AddTicks(7790), null, new DateTime(2021, 3, 4, 4, 4, 11, 711, DateTimeKind.Local).AddTicks(7790) },
                    { 5, new DateTime(2021, 3, 4, 4, 4, 11, 711, DateTimeKind.Local).AddTicks(7790), null, new DateTime(2021, 3, 4, 5, 4, 11, 711, DateTimeKind.Local).AddTicks(7790) },
                    { 6, new DateTime(2021, 3, 4, 5, 4, 11, 711, DateTimeKind.Local).AddTicks(7790), null, new DateTime(2021, 3, 4, 6, 4, 11, 711, DateTimeKind.Local).AddTicks(7790) },
                    { 7, new DateTime(2021, 3, 4, 6, 4, 11, 711, DateTimeKind.Local).AddTicks(7790), null, new DateTime(2021, 3, 4, 7, 4, 11, 711, DateTimeKind.Local).AddTicks(7800) },
                    { 8, new DateTime(2021, 3, 4, 7, 4, 11, 711, DateTimeKind.Local).AddTicks(7800), null, new DateTime(2021, 3, 4, 8, 4, 11, 711, DateTimeKind.Local).AddTicks(7800) },
                    { 9, new DateTime(2021, 3, 4, 8, 4, 11, 711, DateTimeKind.Local).AddTicks(7800), null, new DateTime(2021, 3, 4, 9, 4, 11, 711, DateTimeKind.Local).AddTicks(7800) }
                });

            migrationBuilder.InsertData(
                table: "booking",
                columns: new[] { "Id", "PersonId", "TimeslotId" },
                values: new object[,]
                {
                    { 1, null, 1 },
                    { 2, null, 2 },
                    { 3, null, 3 },
                    { 4, null, 4 },
                    { 5, null, 5 },
                    { 6, null, 6 },
                    { 7, null, 7 },
                    { 8, null, 8 },
                    { 9, null, 9 }
                });

            migrationBuilder.InsertData(
                table: "organization",
                columns: new[] { "Id", "Description", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "Description 1", 1, "House of Padel" },
                    { 2, "Description 2", 2, "Sankt Jörgens" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "BookingId", "Email", "OrganizationId", "PersonId" },
                values: new object[,]
                {
                    { 1, null, "johan.holmberg@domain.se", null, 1 },
                    { 2, null, "joel.holmberg@domain.se", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "resource",
                columns: new[] { "Id", "Name", "OrganizationId", "TypeId" },
                values: new object[,]
                {
                    { 1, "Bana #1", 1, 1 },
                    { 2, "Bana #2", 1, 1 },
                    { 3, "Bana #3", 1, 1 },
                    { 4, "Bana #4", 1, 1 },
                    { 5, "Utomhus 1", 2, 1 },
                    { 6, "Utomhus 2", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "BookingId", "Email", "OrganizationId", "PersonId" },
                values: new object[,]
                {
                    { 3, null, "owner@houseofpadel.se", 1, null },
                    { 4, null, "owner@sanktgorans.se", 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_PersonId",
                table: "booking",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_TimeslotId",
                table: "booking",
                column: "TimeslotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organization_LocationId",
                table: "organization",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPerson_FollowingId",
                table: "PersonPerson",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_resource_OrganizationId",
                table: "resource",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_resource_TypeId",
                table: "resource",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_timeslot_ResourceId",
                table: "timeslot",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_user_BookingId",
                table: "user",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_user_OrganizationId",
                table: "user",
                column: "OrganizationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_PersonId",
                table: "user",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPerson");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "timeslot");

            migrationBuilder.DropTable(
                name: "resource");

            migrationBuilder.DropTable(
                name: "organization");

            migrationBuilder.DropTable(
                name: "resource_type");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
