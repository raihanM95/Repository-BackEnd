using Microsoft.EntityFrameworkCore.Migrations;

namespace MSDSL_DbAccessor.Migrations
{
    public partial class UpdateRepoDevToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewDate",
                table: "RepoDevs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewDev",
                table: "RepoDevs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Handovers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prev_dev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    New_Dev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handovers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Handovers");

            migrationBuilder.DropColumn(
                name: "NewDate",
                table: "RepoDevs");

            migrationBuilder.DropColumn(
                name: "NewDev",
                table: "RepoDevs");
        }
    }
}
