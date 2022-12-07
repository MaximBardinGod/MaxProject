using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Clients_ClientId",
                table: "Mentors");

            migrationBuilder.DropIndex(
                name: "IX_Mentors_ClientId",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Mentors");

            migrationBuilder.AddColumn<int>(
                name: "MentorsId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MentorsId",
                table: "Clients",
                column: "MentorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Mentors_MentorsId",
                table: "Clients",
                column: "MentorsId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Mentors_MentorsId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_MentorsId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MentorsId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Mentors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_ClientId",
                table: "Mentors",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Clients_ClientId",
                table: "Mentors",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
