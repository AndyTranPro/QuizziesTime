using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizzApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Content", "CorrectAnswer", "Option1", "Option2", "Option3", "Option4" },
                values: new object[,]
                {
                    { 1, "What is the capital of France?", "Paris", "Paris", "London", "Berlin", "Madrid" },
                    { 2, "What is the capital of Germany?", "Berlin", "Paris", "London", "Berlin", "Madrid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
