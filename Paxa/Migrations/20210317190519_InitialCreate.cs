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
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    PersonId = table.Column<int>(type: "integer", nullable: true),
                    OrganizationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
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
                    HostId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_booking_timeslot_TimeslotId",
                        column: x => x.TimeslotId,
                        principalTable: "timeslot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_user_HostId",
                        column: x => x.HostId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, new DateTime(2021, 3, 17, 20, 5, 18, 540, DateTimeKind.Local).AddTicks(9760), null, new DateTime(2021, 3, 17, 21, 5, 18, 551, DateTimeKind.Local).AddTicks(3650) },
                    { 2, new DateTime(2021, 3, 17, 21, 5, 18, 551, DateTimeKind.Local).AddTicks(4210), null, new DateTime(2021, 3, 17, 22, 5, 18, 551, DateTimeKind.Local).AddTicks(4220) },
                    { 3, new DateTime(2021, 3, 17, 22, 5, 18, 551, DateTimeKind.Local).AddTicks(4220), null, new DateTime(2021, 3, 17, 23, 5, 18, 551, DateTimeKind.Local).AddTicks(4220) },
                    { 4, new DateTime(2021, 3, 17, 23, 5, 18, 551, DateTimeKind.Local).AddTicks(4220), null, new DateTime(2021, 3, 18, 0, 5, 18, 551, DateTimeKind.Local).AddTicks(4220) },
                    { 5, new DateTime(2021, 3, 18, 0, 5, 18, 551, DateTimeKind.Local).AddTicks(4230), null, new DateTime(2021, 3, 18, 1, 5, 18, 551, DateTimeKind.Local).AddTicks(4230) },
                    { 6, new DateTime(2021, 3, 18, 1, 5, 18, 551, DateTimeKind.Local).AddTicks(4230), null, new DateTime(2021, 3, 18, 2, 5, 18, 551, DateTimeKind.Local).AddTicks(4230) },
                    { 7, new DateTime(2021, 3, 18, 2, 5, 18, 551, DateTimeKind.Local).AddTicks(4230), null, new DateTime(2021, 3, 18, 3, 5, 18, 551, DateTimeKind.Local).AddTicks(4230) },
                    { 8, new DateTime(2021, 3, 18, 3, 5, 18, 551, DateTimeKind.Local).AddTicks(4240), null, new DateTime(2021, 3, 18, 4, 5, 18, 551, DateTimeKind.Local).AddTicks(4240) },
                    { 9, new DateTime(2021, 3, 18, 4, 5, 18, 551, DateTimeKind.Local).AddTicks(4240), null, new DateTime(2021, 3, 18, 5, 5, 18, 551, DateTimeKind.Local).AddTicks(4240) }
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
                columns: new[] { "Id", "Email", "OrganizationId", "Password", "PersonId" },
                values: new object[,]
                {
                    { 1, "johan.holmberg@domain.se", null, null, 1 },
                    { 2, "joel.holmberg@domain.se", null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "booking",
                columns: new[] { "Id", "HostId", "TimeslotId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 3, 1, 3 },
                    { 2, 2, 2 }
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
                columns: new[] { "Id", "Email", "OrganizationId", "Password", "PersonId" },
                values: new object[,]
                {
                    { 3, "owner@houseofpadel.se", 1, null, null },
                    { 4, "owner@sanktgorans.se", 2, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_HostId",
                table: "booking",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_TimeslotId",
                table: "booking",
                column: "TimeslotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingPerson_ParticipantsId",
                table: "BookingPerson",
                column: "ParticipantsId");

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
                name: "IX_user_OrganizationId",
                table: "user",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_user_PersonId",
                table: "user",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingPerson");

            migrationBuilder.DropTable(
                name: "PersonPerson");

            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "timeslot");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "resource");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "organization");

            migrationBuilder.DropTable(
                name: "resource_type");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
