using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuickApp.Migrations
{
    public partial class EmployeeWithSalaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredFrom",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredTo",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedWorkFrom",
                table: "EmployeeDay",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedWorkTo",
                table: "EmployeeDay",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveFrom = table.Column<DateTime>(nullable: false),
                    ActiveTo = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    FixedHourlyRate = table.Column<float>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    MonthlyGrossIncome = table.Column<float>(nullable: false),
                    TakingsPercentage = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RegisteredFrom",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RegisteredTo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PlannedWorkFrom",
                table: "EmployeeDay");

            migrationBuilder.DropColumn(
                name: "PlannedWorkTo",
                table: "EmployeeDay");
        }
    }
}
