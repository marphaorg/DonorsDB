using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CampaignProfileEntityAddedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Users_CreatedBYID",
                table: "Campaign");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Campaign_DonationForID",
                table: "Donations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign");

            migrationBuilder.RenameTable(
                name: "Campaign",
                newName: "Campaigns");

            migrationBuilder.RenameIndex(
                name: "IX_Campaign_CreatedBYID",
                table: "Campaigns",
                newName: "IX_Campaigns_CreatedBYID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns",
                column: "CampaignID");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_CreatedBYID",
                table: "Campaigns",
                column: "CreatedBYID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Campaigns_DonationForID",
                table: "Donations",
                column: "DonationForID",
                principalTable: "Campaigns",
                principalColumn: "CampaignID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_CreatedBYID",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Campaigns_DonationForID",
                table: "Donations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns");

            migrationBuilder.RenameTable(
                name: "Campaigns",
                newName: "Campaign");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_CreatedBYID",
                table: "Campaign",
                newName: "IX_Campaign_CreatedBYID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign",
                column: "CampaignID");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Users_CreatedBYID",
                table: "Campaign",
                column: "CreatedBYID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Campaign_DonationForID",
                table: "Donations",
                column: "DonationForID",
                principalTable: "Campaign",
                principalColumn: "CampaignID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
