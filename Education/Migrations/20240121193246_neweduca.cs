using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Migrations
{
    public partial class neweduca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterTrainersIconUrl",
                table: "MasterTrainers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterTrainersIconUrl",
                table: "MasterTrainers");
        }
    }
}
