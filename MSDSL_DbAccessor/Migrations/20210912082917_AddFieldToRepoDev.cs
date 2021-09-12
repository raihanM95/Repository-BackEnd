using Microsoft.EntityFrameworkCore.Migrations;

namespace MSDSL_DbAccessor.Migrations
{
    public partial class AddFieldToRepoDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrevDev",
                table: "RepoDevs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrevDev",
                table: "RepoDevs");
        }
    }
}
