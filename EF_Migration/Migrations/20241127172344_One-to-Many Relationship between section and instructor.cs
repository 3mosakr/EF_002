using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Migration.Migrations
{
    /// <inheritdoc />
    public partial class OnetoManyRelationshipbetweensectionandinstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_InstructorId",
                table: "Sections",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Instructors_InstructorId",
                table: "Sections",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Instructors_InstructorId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_InstructorId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Sections");
        }
    }
}
