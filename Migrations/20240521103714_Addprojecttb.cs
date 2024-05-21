using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class Addprojecttb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectLeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estimatedbudget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Totalamountspent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estimatedprojectduration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectProgress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
