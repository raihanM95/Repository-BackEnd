using Microsoft.EntityFrameworkCore.Migrations;

namespace MSDSL_DbAccessor.Migrations
{
    public partial class AddHanOverToDatabae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AssignDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepoID = table.Column<int>(type: "int", nullable: false),
                    DevID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handovers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Handovers_Developers_DevID",
                        column: x => x.DevID,
                        principalTable: "Developers",
                        principalColumn: "DeveloperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Handovers_RepositoryLists_RepoID",
                        column: x => x.RepoID,
                        principalTable: "RepositoryLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Handovers_DevID",
                table: "Handovers",
                column: "DevID");

            migrationBuilder.CreateIndex(
                name: "IX_Handovers_RepoID",
                table: "Handovers",
                column: "RepoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Handovers");
        }
    }
}
