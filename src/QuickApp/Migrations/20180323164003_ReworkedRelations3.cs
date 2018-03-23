using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuickApp.Migrations
{
    public partial class ReworkedRelations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Events_EventId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EventId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "DayEvaluationRating",
                columns: table => new
                {
                    DayEvaluationId = table.Column<int>(nullable: false),
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayEvaluationRating", x => new { x.DayEvaluationId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_DayEvaluationRating_DayEvaluations_DayEvaluationId",
                        column: x => x.DayEvaluationId,
                        principalTable: "DayEvaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayEvaluationRating_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDay",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    DayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDay", x => new { x.EmployeeId, x.DayId });
                    table.ForeignKey(
                        name: "FK_EmployeeDay_DayOverviews_DayId",
                        column: x => x.DayId,
                        principalTable: "DayOverviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDay_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDay",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    DayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDay", x => new { x.EventId, x.DayId });
                    table.ForeignKey(
                        name: "FK_EventDay_DayOverviews_DayId",
                        column: x => x.DayId,
                        principalTable: "DayOverviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDay_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEmployee",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEmployee", x => new { x.EventId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EventEmployee_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEmployee_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEvaluationRating",
                columns: table => new
                {
                    EventEvaluationId = table.Column<int>(nullable: false),
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEvaluationRating", x => new { x.EventEvaluationId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_EventEvaluationRating_EventEvaluations_EventEvaluationId",
                        column: x => x.EventEvaluationId,
                        principalTable: "EventEvaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEvaluationRating_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEventFlag",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    EventFlagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEventFlag", x => new { x.EventId, x.EventFlagId });
                    table.ForeignKey(
                        name: "FK_EventEventFlag_EventFlags_EventFlagId",
                        column: x => x.EventFlagId,
                        principalTable: "EventFlags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEventFlag_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEventTask",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    EventTaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEventTask", x => new { x.EventId, x.EventTaskId });
                    table.ForeignKey(
                        name: "FK_EventEventTask_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEventTask_EventTasks_EventTaskId",
                        column: x => x.EventTaskId,
                        principalTable: "EventTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayEvaluationRating_RatingId",
                table: "DayEvaluationRating",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDay_DayId",
                table: "EmployeeDay",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDay_DayId",
                table: "EventDay",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEmployee_EmployeeId",
                table: "EventEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEvaluationRating_RatingId",
                table: "EventEvaluationRating",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEventFlag_EventFlagId",
                table: "EventEventFlag",
                column: "EventFlagId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEventTask_EventTaskId",
                table: "EventEventTask",
                column: "EventTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayEvaluationRating");

            migrationBuilder.DropTable(
                name: "EmployeeDay");

            migrationBuilder.DropTable(
                name: "EventDay");

            migrationBuilder.DropTable(
                name: "EventEmployee");

            migrationBuilder.DropTable(
                name: "EventEvaluationRating");

            migrationBuilder.DropTable(
                name: "EventEventFlag");

            migrationBuilder.DropTable(
                name: "EventEventTask");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EventId",
                table: "Employees",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Events_EventId",
                table: "Employees",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
