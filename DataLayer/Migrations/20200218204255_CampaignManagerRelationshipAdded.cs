using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CampaignManagerRelationshipAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_CreatedBYID",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "CreatedBYID",
                table: "Campaigns",
                newName: "CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_CreatedBYID",
                table: "Campaigns",
                newName: "IX_Campaigns_CreatedByID");

            migrationBuilder.AddColumn<Guid>(
                name: "ManagedByID",
                table: "Campaigns",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_CampaignID",
                table: "Campaigns",
                column: "CampaignID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_CreatedByID",
                table: "Campaigns",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_CampaignID",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_CreatedByID",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ManagedByID",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                table: "Campaigns",
                newName: "CreatedBYID");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_CreatedByID",
                table: "Campaigns",
                newName: "IX_Campaigns_CreatedBYID");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_CreatedBYID",
                table: "Campaigns",
                column: "CreatedBYID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
