using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorAuthIssueRepro.Server.Data.Migrations
{
    public partial class RoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "B6E32223-FA3A-4D0D-8E48-622601BBD044", "b4706ff3-2751-4d4d-b946-b4072faec594", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9340A34A-70ED-4DC0-8EE6-580B2198C088", "be597d6d-b550-49ad-aab5-322685750acf", "Standard", "STANDARD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9340A34A-70ED-4DC0-8EE6-580B2198C088");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B6E32223-FA3A-4D0D-8E48-622601BBD044");
        }
    }
}
