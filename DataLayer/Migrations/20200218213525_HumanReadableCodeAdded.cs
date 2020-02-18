using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class HumanReadableCodeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonorCode",
                table: "Donors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CampaignCode",
                table: "Campaigns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonorCode",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "CampaignCode",
                table: "Campaigns");
        }
    }
}
