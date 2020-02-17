using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CampaignProfileEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DonationForID",
                table: "Donations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignID = table.Column<Guid>(nullable: false),
                    CampaignTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBYID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignID);
                    table.ForeignKey(
                        name: "FK_Campaign_Users_CreatedBYID",
                        column: x => x.CreatedBYID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonationForID",
                table: "Donations",
                column: "DonationForID");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_CreatedBYID",
                table: "Campaign",
                column: "CreatedBYID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Campaign_DonationForID",
                table: "Donations",
                column: "DonationForID",
                principalTable: "Campaign",
                principalColumn: "CampaignID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Campaign_DonationForID",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropIndex(
                name: "IX_Donations_DonationForID",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "DonationForID",
                table: "Donations");
        }
    }
}
