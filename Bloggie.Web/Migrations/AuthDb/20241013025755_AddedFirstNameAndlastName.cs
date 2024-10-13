using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddedFirstNameAndlastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd4bda95-a05b-449d-bb80-7ddfbecc1860");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd4bda95-a05b-449d-bb80-7ddfbecc1860", 0, "8ed7b3a5-a578-47d6-a4f0-e8b25b12a138", "ApplicationUser", "superadmin@bloggie.com", false, "Super", "Admin", false, null, "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAELlLM0vPONVZ5yFQXKirOS5rVUoEcw8DEhgIZppOC97Y+sboHFcwA7bJaO9kPIuxmQ==", "888-888-8888", false, "96459a8e-f812-44d4-a50a-1bb79f8e7fe1", false, "superadmin@bloggie.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd4bda95-a05b-449d-bb80-7ddfbecc1860",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "20df4382-b0a9-49ac-9033-2792439d9489", "AQAAAAIAAYagAAAAEI+nTqAL8CnuT2LonNDOa4cQoPT+N9VBaAQClOf7a3tl2WCKpbe0ZjGnphurpZ2mVA==", null, "7de818bd-af46-446d-8904-4de4700cf0b3" });
        }
    }
}
