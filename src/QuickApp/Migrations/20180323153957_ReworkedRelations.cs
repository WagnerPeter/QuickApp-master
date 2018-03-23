using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuickApp.Migrations
{
    public partial class ReworkedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayEvaluations_EventEvaluations_EventEvaluationId",
                table: "DayEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DayOverviews_DayOverviewId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EventFlags_Events_EventId",
                table: "EventFlags");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_DayOverviews_DayOverviewId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTasks_Events_EventId",
                table: "EventTasks");

            migrationBuilder.DropIndex(
                name: "IX_EventTasks_EventId",
                table: "EventTasks");

            migrationBuilder.DropIndex(
                name: "IX_Events_DayOverviewId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_EventFlags_EventId",
                table: "EventFlags");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DayOverviewId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_DayEvaluations_EventEvaluationId",
                table: "DayEvaluations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventTasks");

            migrationBuilder.DropColumn(
                name: "DayOverviewId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventFlags");

            migrationBuilder.DropColumn(
                name: "AtmosphereRating",
                table: "EventEvaluations");

            migrationBuilder.DropColumn(
                name: "AttendanceRating",
                table: "EventEvaluations");

            migrationBuilder.DropColumn(
                name: "OrganisationalRating",
                table: "EventEvaluations");

            migrationBuilder.DropColumn(
                name: "DayOverviewId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EventEvaluationId",
                table: "DayEvaluations");

            migrationBuilder.DropColumn(
                name: "TidynessEvaluation",
                table: "DayEvaluations");

            migrationBuilder.DropColumn(
                name: "TidynessRating",
                table: "DayEvaluations");

            migrationBuilder.RenameColumn(
                name: "StockRunngingLow",
                table: "DayOverviews",
                newName: "StockRunningLow");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "DayEvaluations",
                newName: "WorkingTo");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "DayEvaluations",
                newName: "WorkingFrom");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Evaluation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Score = table.Column<float>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.RenameColumn(
                name: "StockRunningLow",
                table: "DayOverviews",
                newName: "StockRunngingLow");

            migrationBuilder.RenameColumn(
                name: "WorkingTo",
                table: "DayEvaluations",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "WorkingFrom",
                table: "DayEvaluations",
                newName: "From");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOverviewId",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventFlags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AtmosphereRating",
                table: "EventEvaluations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttendanceRating",
                table: "EventEvaluations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganisationalRating",
                table: "EventEvaluations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayOverviewId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventEvaluationId",
                table: "DayEvaluations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TidynessEvaluation",
                table: "DayEvaluations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TidynessRating",
                table: "DayEvaluations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventTasks_EventId",
                table: "EventTasks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DayOverviewId",
                table: "Events",
                column: "DayOverviewId");

            migrationBuilder.CreateIndex(
                name: "IX_EventFlags_EventId",
                table: "EventFlags",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DayOverviewId",
                table: "Employees",
                column: "DayOverviewId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEvaluations_EventEvaluationId",
                table: "DayEvaluations",
                column: "EventEvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayEvaluations_EventEvaluations_EventEvaluationId",
                table: "DayEvaluations",
                column: "EventEvaluationId",
                principalTable: "EventEvaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DayOverviews_DayOverviewId",
                table: "Employees",
                column: "DayOverviewId",
                principalTable: "DayOverviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventFlags_Events_EventId",
                table: "EventFlags",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_DayOverviews_DayOverviewId",
                table: "Events",
                column: "DayOverviewId",
                principalTable: "DayOverviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTasks_Events_EventId",
                table: "EventTasks",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
