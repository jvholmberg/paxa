using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Paxa.Migrations
{
    public partial class SupportForMultipleOrganizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Address_AddressId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Organizations_OrganizationId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Persons_PersonId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_RatingType_TypeId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingType",
                table: "RatingType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "RatingType",
                newName: "RatingTypes");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_TypeId",
                table: "Ratings",
                newName: "IX_Ratings_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_PersonId",
                table: "Ratings",
                newName: "IX_Ratings_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_OrganizationId",
                table: "Ratings",
                newName: "IX_Ratings_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingTypes",
                table: "RatingTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MembershipRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipRoles", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 0, 28, 9, 461, DateTimeKind.Local).AddTicks(3860), new DateTime(2021, 12, 30, 1, 28, 9, 476, DateTimeKind.Local).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 1, 28, 9, 476, DateTimeKind.Local).AddTicks(7880), new DateTime(2021, 12, 30, 2, 28, 9, 476, DateTimeKind.Local).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 2, 28, 9, 476, DateTimeKind.Local).AddTicks(7900), new DateTime(2021, 12, 30, 3, 28, 9, 476, DateTimeKind.Local).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 3, 28, 9, 476, DateTimeKind.Local).AddTicks(7900), new DateTime(2021, 12, 30, 4, 28, 9, 476, DateTimeKind.Local).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 4, 28, 9, 476, DateTimeKind.Local).AddTicks(7910), new DateTime(2021, 12, 30, 5, 28, 9, 476, DateTimeKind.Local).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 5, 28, 9, 476, DateTimeKind.Local).AddTicks(7920), new DateTime(2021, 12, 30, 6, 28, 9, 476, DateTimeKind.Local).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 6, 28, 9, 476, DateTimeKind.Local).AddTicks(7920), new DateTime(2021, 12, 30, 7, 28, 9, 476, DateTimeKind.Local).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 7, 28, 9, 476, DateTimeKind.Local).AddTicks(7930), new DateTime(2021, 12, 30, 8, 28, 9, 476, DateTimeKind.Local).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 30, 8, 28, 9, 476, DateTimeKind.Local).AddTicks(7930), new DateTime(2021, 12, 30, 9, 28, 9, 476, DateTimeKind.Local).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$dqciHWvc82xGklIUwbwT5.dC0k.h8vY4ow7BEl/9zq2qo.Ib3Dr1u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$1phOKJw7GZo12M5Iaxolz.91pYupBcoy9qc1TLOgx8vQ2urjox0Gu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$z1WJHqL9HgnU/NAHgybTMeE8R5Zw8ExmX8FSqn69He08JM0ZwHPhq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$./GE/okJIvnfSQ6AgFGrne.k6.h5k0iFnZVlpJbH61xf2T17sgYOm");

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "OrganizationId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 2 }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Organizations_OrganizationId",
                table: "Ratings",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Persons_PersonId",
                table: "Ratings",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_RatingTypes_TypeId",
                table: "Ratings",
                column: "TypeId",
                principalTable: "RatingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Organizations_OrganizationId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Persons_PersonId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_RatingTypes_TypeId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "MembershipRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingTypes",
                table: "RatingTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "RefreshToken");

            migrationBuilder.RenameTable(
                name: "RatingTypes",
                newName: "RatingType");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_TypeId",
                table: "Rating",
                newName: "IX_Rating_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_PersonId",
                table: "Rating",
                newName: "IX_Rating_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_OrganizationId",
                table: "Rating",
                newName: "IX_Rating_OrganizationId");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingType",
                table: "RatingType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 28, 19, 16, 23, 181, DateTimeKind.Local).AddTicks(3390), new DateTime(2021, 12, 28, 20, 16, 23, 191, DateTimeKind.Local).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 28, 20, 16, 23, 191, DateTimeKind.Local).AddTicks(1710), new DateTime(2021, 12, 28, 21, 16, 23, 191, DateTimeKind.Local).AddTicks(1720) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 28, 21, 16, 23, 191, DateTimeKind.Local).AddTicks(1720), new DateTime(2021, 12, 28, 22, 16, 23, 191, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 28, 22, 16, 23, 191, DateTimeKind.Local).AddTicks(1730), new DateTime(2021, 12, 28, 23, 16, 23, 191, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 28, 23, 16, 23, 191, DateTimeKind.Local).AddTicks(1730), new DateTime(2021, 12, 29, 0, 16, 23, 191, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 29, 0, 16, 23, 191, DateTimeKind.Local).AddTicks(1730), new DateTime(2021, 12, 29, 1, 16, 23, 191, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 29, 1, 16, 23, 191, DateTimeKind.Local).AddTicks(1740), new DateTime(2021, 12, 29, 2, 16, 23, 191, DateTimeKind.Local).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 29, 2, 16, 23, 191, DateTimeKind.Local).AddTicks(1740), new DateTime(2021, 12, 29, 3, 16, 23, 191, DateTimeKind.Local).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "Timeslots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "From", "To" },
                values: new object[] { new DateTime(2021, 12, 29, 3, 16, 23, 191, DateTimeKind.Local).AddTicks(1740), new DateTime(2021, 12, 29, 4, 16, 23, 191, DateTimeKind.Local).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$JZzb3UEmWePI1JDH/YgkIufoKZkMV/BKVyxKZ5z0IokUIRzVoIkzS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$DjnblTSZliRZX/DsjyKONepALMpizN/V2Srh7F5YeA3vTSDrzgzVG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OrganizationId", "PasswordHash" },
                values: new object[] { 1, "$2a$11$5Hnu4nbeZ27RC9DgZsteveGmvfsJL5d81I91NDRnD1hBrbMMcPRPm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "OrganizationId", "PasswordHash" },
                values: new object[] { 2, "$2a$11$qgfVB/zMfenxOZCtwTYDLu7hTVqeHN9rlx4pccG9Ym//F49abhGma" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Address_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Organizations_OrganizationId",
                table: "Rating",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Persons_PersonId",
                table: "Rating",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_RatingType_TypeId",
                table: "Rating",
                column: "TypeId",
                principalTable: "RatingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
