using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ClientID = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRoster",
                columns: table => new
                {
                    ParticipantID = table.Column<string>(nullable: false),
                    ProjectID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRoster", x => new { x.ProjectID, x.ParticipantID });
                    table.ForeignKey(
                        name: "FK_ProjectRoster_People_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectRoster_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRoster_ParticipantID",
                table: "ProjectRoster",
                column: "ParticipantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectRoster");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
