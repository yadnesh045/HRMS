using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class Add34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthInsurance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsPF",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "EmployeeDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendanceDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledInTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledOutTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualInTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualOutTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overtime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EarlyGoingBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunchRecords = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDatas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDatas");

            migrationBuilder.AddColumn<bool>(
                name: "HealthInsurance",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPF",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
