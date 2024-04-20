using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementApplication.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmployeeDetailsEmployeeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Employees_EmployeeDetailsEmployeeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_EmployeeDetailsEmployeeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EmployeeDetailsEmployeeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmployeeDetailsEmployeeId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "EmployeeDetailsEmployeeId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "EmployeeDetailsProjects",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetailsProjects", x => new { x.EmployeesEmployeeId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeDetailsProjects_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDetailsProjects_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetailsSkills",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetailsSkills", x => new { x.EmployeesEmployeeId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_EmployeeDetailsSkills_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDetailsSkills_Skills_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetailsProjects_ProjectsProjectId",
                table: "EmployeeDetailsProjects",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetailsSkills_SkillsSkillId",
                table: "EmployeeDetailsSkills",
                column: "SkillsSkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetailsProjects");

            migrationBuilder.DropTable(
                name: "EmployeeDetailsSkills");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDetailsEmployeeId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDetailsEmployeeId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EmployeeDetailsEmployeeId",
                table: "Skills",
                column: "EmployeeDetailsEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeDetailsEmployeeId",
                table: "Projects",
                column: "EmployeeDetailsEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmployeeDetailsEmployeeId",
                table: "Projects",
                column: "EmployeeDetailsEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Employees_EmployeeDetailsEmployeeId",
                table: "Skills",
                column: "EmployeeDetailsEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
