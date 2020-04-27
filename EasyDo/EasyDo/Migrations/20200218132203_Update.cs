using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyDo.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_ContactId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Emails",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ContactId",
                table: "Emails",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_ContactId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Emails");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Emails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ContactId",
                table: "Emails",
                column: "ContactId",
                unique: true);
        }
    }
}
