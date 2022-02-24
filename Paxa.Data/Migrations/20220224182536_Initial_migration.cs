using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Paxa.Data.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendshipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Longitude = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timestamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hours = table.Column<int>(type: "integer", nullable: false),
                    Minutes = table.Column<int>(type: "integer", nullable: false),
                    Seconds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timestamps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weekdays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekdays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromPersonId = table.Column<int>(type: "integer", nullable: false),
                    ToPersonId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_FriendshipTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "FriendshipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friendships_Persons_FromPersonId",
                        column: x => x.FromPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friendships_Persons_ToPersonId",
                        column: x => x.ToPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
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
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_RatingTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RatingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schemas_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_MembershipRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "MembershipRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: false),
                    Revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false),
                    SchemaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Resources_ResourceTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_Schemas_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "Schemas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SchemaEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromTimestampId = table.Column<int>(type: "integer", nullable: false),
                    ToTimestampId = table.Column<int>(type: "integer", nullable: false),
                    WeekdayId = table.Column<int>(type: "integer", nullable: false),
                    SchemaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemaEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemaEntries_Schemas_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "Schemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchemaEntries_Timestamps_FromTimestampId",
                        column: x => x.FromTimestampId,
                        principalTable: "Timestamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchemaEntries_Timestamps_ToTimestampId",
                        column: x => x.ToTimestampId,
                        principalTable: "Timestamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchemaEntries_Weekdays_WeekdayId",
                        column: x => x.WeekdayId,
                        principalTable: "Weekdays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timeslots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceId = table.Column<int>(type: "integer", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timeslots_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeslotId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Timeslots_TimeslotId",
                        column: x => x.TimeslotId,
                        principalTable: "Timeslots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    BookingId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_ParticipantTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ParticipantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Test city", "Sweden", "73574", "Cool road 1" },
                    { 2, "Test city", "Sweden", "73574", "Not so cool road 4" },
                    { 3, "Some city", "Sweden", "43715", "Regular road 21" },
                    { 4, "Some city", "Sweden", "43715", "Unregular road 2" }
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
                table: "MembershipRoles",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "OWNER", "Description for owner-role", "Owner" },
                    { 2, "ADMIN", "Description for admin-role", "Admin" },
                    { 3, "MEMBER", "Description for member-role", "Member" },
                    { 4, "TRIAL", "Description for trial-role", "Trial" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "LocationId", "Name" },
                values: new object[] { 3, "Description 2", null, "Hard to find" });

            migrationBuilder.InsertData(
                table: "RatingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "General" },
                    { 2, "Personnel" },
                    { 3, "Washrooms" },
                    { 4, "Building" }
                });

            migrationBuilder.InsertData(
                table: "ResourceTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description", "Padel" },
                    { 2, "Description", "Tennis" },
                    { 3, "Description", "Badminton" },
                    { 4, "Description", "Table tennis" },
                    { 5, "Description", "Riding" }
                });

            migrationBuilder.InsertData(
                table: "Timestamps",
                columns: new[] { "Id", "Hours", "Minutes", "Seconds" },
                values: new object[,]
                {
                    { 1, 10, 0, 0 },
                    { 2, 11, 0, 0 },
                    { 3, 11, 0, 0 },
                    { 4, 12, 0, 0 },
                    { 5, 10, 0, 0 },
                    { 6, 11, 0, 0 },
                    { 7, 11, 0, 0 },
                    { 8, 12, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Weekdays",
                columns: new[] { "Id", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "Sunday", 0 },
                    { 2, "Monday", 1 },
                    { 3, "Tuesday", 2 },
                    { 4, "Wednesday", 3 },
                    { 5, "Thursday", 4 },
                    { 6, "Friday", 5 },
                    { 7, "Saturday", 6 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "Description 1", 1, "Valid Inc" },
                    { 2, "Description 2", 2, "Correct Inc" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "AddressId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Johan", "Holmberg" },
                    { 2, 2, "Joel", "Holmberg" },
                    { 3, 3, "Sam", "Samson" },
                    { 4, 4, "John", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "OrganizationId", "PersonId", "TypeId", "Value" },
                values: new object[] { 1, null, 2, 1, 5 });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "OrganizationId", "SchemaId", "TypeId" },
                values: new object[,]
                {
                    { 1, "Bana #1", 1, null, 1 },
                    { 2, "Bana #2", 1, null, 1 },
                    { 3, "Bana #3", 1, null, 1 },
                    { 4, "Bana #4", 1, null, 1 },
                    { 5, "Utomhus 1", 2, null, 1 },
                    { 6, "Utomhus 2", 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Schemas",
                columns: new[] { "Id", "Active", "Name", "OrganizationId" },
                values: new object[] { 1, true, "Default Schema", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PersonId" },
                values: new object[,]
                {
                    { 1, "johan.holmberg@domain.se", "$2a$11$QMRxbdrQUPbeQxras2xCse4jLoELG.SM6SY5mPVO40ICcQ31FH9TG", 1 },
                    { 2, "joel.holmberg@domain.se", "$2a$11$uYNVQGc2GiAJUeMswoaVzOXy77v3TWM5TRl6D7jpLfb.ekmvkwpda", 2 },
                    { 3, "owner@houseofpadel.se", "$2a$11$q/ehJXP0PXtSKG8v8BuPreO5WB6vB3YebRFf1v4C9sRY5ZsVJ83ZC", 3 },
                    { 4, "owner@sanktgorans.se", "$2a$11$bu/KeOmQHPz329H14XZm6uqy7CYQc30Zy.2I7s8q3kRD263z9Gk8K", 4 }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "OrganizationId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 3 },
                    { 2, 2, 1, 4 },
                    { 3, 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "SchemaEntries",
                columns: new[] { "Id", "FromTimestampId", "SchemaId", "ToTimestampId", "WeekdayId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 1 },
                    { 2, 3, 1, 4, 1 },
                    { 3, 5, 1, 6, 7 },
                    { 4, 7, 1, 8, 7 }
                });

            migrationBuilder.InsertData(
                table: "Timeslots",
                columns: new[] { "Id", "From", "ResourceId", "To" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 24, 18, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 24, 19, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) },
                    { 2, new DateTime(2022, 2, 24, 19, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 24, 20, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) },
                    { 3, new DateTime(2022, 2, 24, 20, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 24, 21, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) },
                    { 4, new DateTime(2022, 2, 24, 21, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 24, 22, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) },
                    { 5, new DateTime(2022, 2, 24, 22, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 24, 23, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) },
                    { 6, new DateTime(2022, 2, 24, 23, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 25, 0, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) },
                    { 7, new DateTime(2022, 2, 25, 0, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 25, 1, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) },
                    { 8, new DateTime(2022, 2, 25, 1, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 25, 2, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) },
                    { 9, new DateTime(2022, 2, 25, 2, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490), 1, new DateTime(2022, 2, 25, 3, 25, 35, 516, DateTimeKind.Utc).AddTicks(7490) }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "PersonId", "TimeslotId" },
                values: new object[,]
                {
                    { 1, null, 1 },
                    { 2, null, 2 },
                    { 3, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PersonId",
                table: "Bookings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeslotId",
                table: "Bookings",
                column: "TimeslotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FromPersonId",
                table: "Friendships",
                column: "FromPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_ToPersonId",
                table: "Friendships",
                column: "ToPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_TypeId",
                table: "Friendships",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_OrganizationId",
                table: "Memberships",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_RoleId",
                table: "Memberships",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId",
                table: "Memberships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_LocationId",
                table: "Organizations",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_BookingId",
                table: "Participants",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PersonId",
                table: "Participants",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_TypeId",
                table: "Participants",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId",
                table: "Persons",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OrganizationId",
                table: "Ratings",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PersonId",
                table: "Ratings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TypeId",
                table: "Ratings",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_OrganizationId",
                table: "Resources",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_SchemaId",
                table: "Resources",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_TypeId",
                table: "Resources",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemaEntries_FromTimestampId",
                table: "SchemaEntries",
                column: "FromTimestampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchemaEntries_SchemaId",
                table: "SchemaEntries",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemaEntries_ToTimestampId",
                table: "SchemaEntries",
                column: "ToTimestampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchemaEntries_WeekdayId",
                table: "SchemaEntries",
                column: "WeekdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemas_OrganizationId",
                table: "Schemas",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_ResourceId",
                table: "Timeslots",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SchemaEntries");

            migrationBuilder.DropTable(
                name: "FriendshipTypes");

            migrationBuilder.DropTable(
                name: "MembershipRoles");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ParticipantTypes");

            migrationBuilder.DropTable(
                name: "RatingTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Timestamps");

            migrationBuilder.DropTable(
                name: "Weekdays");

            migrationBuilder.DropTable(
                name: "Timeslots");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropTable(
                name: "Schemas");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
