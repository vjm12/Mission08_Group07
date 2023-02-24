using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission08_Group07.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    QuadrantNumber = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "QuadrantNumber", "Task" },
                values: new object[] { 1, 1, false, new DateTime(2023, 2, 25, 15, 19, 0, 875, DateTimeKind.Local).AddTicks(4594), 1, "Clean dishes" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "QuadrantNumber", "Task" },
                values: new object[] { 2, 2, false, new DateTime(2023, 2, 27, 15, 19, 0, 877, DateTimeKind.Local).AddTicks(9730), 2, "Go for a run" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "QuadrantNumber", "Task" },
                values: new object[] { 3, 3, false, new DateTime(2023, 2, 26, 15, 19, 0, 878, DateTimeKind.Local).AddTicks(465), 3, "Read a book" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "QuadrantNumber", "Task" },
                values: new object[] { 4, 4, false, new DateTime(2023, 2, 28, 15, 19, 0, 878, DateTimeKind.Local).AddTicks(900), 4, "Call a friend" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryID",
                table: "Responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
