using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace empformajax.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "as1_department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__as1_depa__3213E83FD352DA32", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "as1_designation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__as1_desi__3213E83F9F2E4199", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "as1_skill",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__as1_skil__3213E83FB84260B7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "as1_employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    lastname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    dateofbirth = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    salary = table.Column<int>(type: "int", nullable: true),
                    doj = table.Column<DateTime>(type: "date", nullable: true),
                    departmentid = table.Column<int>(type: "int", nullable: true),
                    designationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__as1_empl__3213E83F7B03E29D", x => x.id);
                    table.ForeignKey(
                        name: "FK_departmentid",
                        column: x => x.departmentid,
                        principalTable: "as1_department",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_designationid",
                        column: x => x.designationid,
                        principalTable: "as1_designation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "as1_empskill",
                columns: table => new
                {
                    Empid = table.Column<int>(type: "int", nullable: false),
                    Skillid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Name", x => new { x.Empid, x.Skillid });
                    table.ForeignKey(
                        name: "FK_emp",
                        column: x => x.Empid,
                        principalTable: "as1_employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_skill",
                        column: x => x.Skillid,
                        principalTable: "as1_skill",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_as1_employee_departmentid",
                table: "as1_employee",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_as1_employee_designationid",
                table: "as1_employee",
                column: "designationid");

            migrationBuilder.CreateIndex(
                name: "IX_as1_empskill_Skillid",
                table: "as1_empskill",
                column: "Skillid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "as1_empskill");

            migrationBuilder.DropTable(
                name: "as1_employee");

            migrationBuilder.DropTable(
                name: "as1_skill");

            migrationBuilder.DropTable(
                name: "as1_department");

            migrationBuilder.DropTable(
                name: "as1_designation");
        }
    }
}
