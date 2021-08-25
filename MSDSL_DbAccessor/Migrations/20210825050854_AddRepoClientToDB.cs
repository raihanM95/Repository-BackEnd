using Microsoft.EntityFrameworkCore.Migrations;

namespace MSDSL_DbAccessor.Migrations
{
    public partial class AddRepoClientToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepoClients",
                columns: table => new
                {
                    RepoClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepoID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    Dates = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepoClients", x => x.RepoClientID);
                    table.ForeignKey(
                        name: "FK_RepoClients_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepoClients_RepositoryLists_RepoID",
                        column: x => x.RepoID,
                        principalTable: "RepositoryLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepoClients_ClientID",
                table: "RepoClients",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_RepoClients_RepoID",
                table: "RepoClients",
                column: "RepoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepoClients");
        }
    }
}
