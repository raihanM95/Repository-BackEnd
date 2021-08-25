using Microsoft.EntityFrameworkCore.Migrations;

namespace MSDSL_DbAccessor.Migrations
{
    public partial class AddRepoDevToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepoDevs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFirstAssign = table.Column<bool>(type: "bit", nullable: false),
                    AssignDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepoID = table.Column<int>(type: "int", nullable: false),
                    DevID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepoDevs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RepoDevs_Developers_DevID",
                        column: x => x.DevID,
                        principalTable: "Developers",
                        principalColumn: "DeveloperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepoDevs_RepositoryLists_RepoID",
                        column: x => x.RepoID,
                        principalTable: "RepositoryLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepoDevs_DevID",
                table: "RepoDevs",
                column: "DevID");

            migrationBuilder.CreateIndex(
                name: "IX_RepoDevs_RepoID",
                table: "RepoDevs",
                column: "RepoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepoDevs");
        }
    }
}
