using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Paxa.Migrations
{
    public partial class NewInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_PersonPerson_Persons_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPerson_Persons_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
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
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_RatingType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RatingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
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
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_ResourceTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PersonId = table.Column<int>(type: "integer", nullable: true),
                    OrganizationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timeslots",
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
                    table.PrimaryKey("PK_Timeslots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timeslots_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeslotId = table.Column<int>(type: "integer", nullable: false),
                    HostId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Timeslots_TimeslotId",
                        column: x => x.TimeslotId,
                        principalTable: "Timeslots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_HostId",
                        column: x => x.HostId,
                        principalTable: "Users",
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
                        name: "FK_BookingPerson_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingPerson_Persons_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Älmhult", "Sweden", "34391", "Femlingehult 2384" },
                    { 2, "Älmhult", "Sweden", "34391", "Femlingehult 2384" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1, "0", "0" },
                    { 2, "99", "99" }
                });

            migrationBuilder.InsertData(
                table: "RatingType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "General" });

            migrationBuilder.InsertData(
                table: "ResourceTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Description", "Padel" });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "From", "ResourceId", "To" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 28, 19, 16, 23, 181, DateTimeKind.Local).AddTicks(3390), null, new DateTime(2021, 12, 28, 20, 16, 23, 191, DateTimeKind.Local).AddTicks(1070) },
                    { 2, new DateTime(2021, 12, 28, 20, 16, 23, 191, DateTimeKind.Local).AddTicks(1710), null, new DateTime(2021, 12, 28, 21, 16, 23, 191, DateTimeKind.Local).AddTicks(1720) },
                    { 3, new DateTime(2021, 12, 28, 21, 16, 23, 191, DateTimeKind.Local).AddTicks(1720), null, new DateTime(2021, 12, 28, 22, 16, 23, 191, DateTimeKind.Local).AddTicks(1730) },
                    { 4, new DateTime(2021, 12, 28, 22, 16, 23, 191, DateTimeKind.Local).AddTicks(1730), null, new DateTime(2021, 12, 28, 23, 16, 23, 191, DateTimeKind.Local).AddTicks(1730) },
                    { 5, new DateTime(2021, 12, 28, 23, 16, 23, 191, DateTimeKind.Local).AddTicks(1730), null, new DateTime(2021, 12, 29, 0, 16, 23, 191, DateTimeKind.Local).AddTicks(1730) },
                    { 6, new DateTime(2021, 12, 29, 0, 16, 23, 191, DateTimeKind.Local).AddTicks(1730), null, new DateTime(2021, 12, 29, 1, 16, 23, 191, DateTimeKind.Local).AddTicks(1730) },
                    { 7, new DateTime(2021, 12, 29, 1, 16, 23, 191, DateTimeKind.Local).AddTicks(1740), null, new DateTime(2021, 12, 29, 2, 16, 23, 191, DateTimeKind.Local).AddTicks(1740) },
                    { 8, new DateTime(2021, 12, 29, 2, 16, 23, 191, DateTimeKind.Local).AddTicks(1740), null, new DateTime(2021, 12, 29, 3, 16, 23, 191, DateTimeKind.Local).AddTicks(1740) },
                    { 9, new DateTime(2021, 12, 29, 3, 16, 23, 191, DateTimeKind.Local).AddTicks(1740), null, new DateTime(2021, 12, 29, 4, 16, 23, 191, DateTimeKind.Local).AddTicks(1740) }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "Description 1", 1, "House of Padel" },
                    { 2, "Description 2", 2, "Sankt Jörgens" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "AddressId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "Johan", "Holmberg", null },
                    { 2, 2, "Joel", "Holmberg", null }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "OrganizationId", "PersonId", "TypeId", "Value" },
                values: new object[] { 1, null, 2, 1, 5 });

            migrationBuilder.InsertData(
                table: "Resources",
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
                table: "Users",
                columns: new[] { "Id", "Email", "OrganizationId", "PasswordHash", "PersonId" },
                values: new object[,]
                {
                    { 1, "johan.holmberg@domain.se", null, "$2a$11$JZzb3UEmWePI1JDH/YgkIufoKZkMV/BKVyxKZ5z0IokUIRzVoIkzS", 1 },
                    { 2, "joel.holmberg@domain.se", null, "$2a$11$DjnblTSZliRZX/DsjyKONepALMpizN/V2Srh7F5YeA3vTSDrzgzVG", 2 },
                    { 3, "owner@houseofpadel.se", 1, "$2a$11$5Hnu4nbeZ27RC9DgZsteveGmvfsJL5d81I91NDRnD1hBrbMMcPRPm", null },
                    { 4, "owner@sanktgorans.se", 2, "$2a$11$qgfVB/zMfenxOZCtwTYDLu7hTVqeHN9rlx4pccG9Ym//F49abhGma", null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "HostId", "TimeslotId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 3, 1, 3 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingPerson_ParticipantsId",
                table: "BookingPerson",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HostId",
                table: "Bookings",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeslotId",
                table: "Bookings",
                column: "TimeslotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_LocationId",
                table: "Organizations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPerson_FollowingId",
                table: "PersonPerson",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId",
                table: "Persons",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_OrganizationId",
                table: "Rating",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PersonId",
                table: "Rating",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_TypeId",
                table: "Rating",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_OrganizationId",
                table: "Resources",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_TypeId",
                table: "Resources",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_ResourceId",
                table: "Timeslots",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingPerson");

            migrationBuilder.DropTable(
                name: "PersonPerson");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "RatingType");

            migrationBuilder.DropTable(
                name: "Timeslots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
