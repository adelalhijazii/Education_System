using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Migrations
{
    public partial class educationnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterCoursesUrl",
                table: "MasterCourses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterCoursesUrl",
                table: "MasterCourses");
        }
    }
}
