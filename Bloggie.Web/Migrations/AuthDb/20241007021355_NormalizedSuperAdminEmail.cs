using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class NormalizedSuperAdminEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd4bda95-a05b-449d-bb80-7ddfbecc1860",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20df4382-b0a9-49ac-9033-2792439d9489", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEI+nTqAL8CnuT2LonNDOa4cQoPT+N9VBaAQClOf7a3tl2WCKpbe0ZjGnphurpZ2mVA==", "7de818bd-af46-446d-8904-4de4700cf0b3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd4bda95-a05b-449d-bb80-7ddfbecc1860",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be72a1e1-0d88-4cda-be70-54aba62e52b8", null, "AQAAAAIAAYagAAAAED/b4gNyWsA8cZJUgMHy1Wkn37495wCXAk8VNsy8CsAfeROqpoBbctTIgzYG3PbD8w==", "0c286c13-3efd-4071-a570-2e4121309ba8" });
        }
    }
}
