using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace treinamento_.NET_Core.Migrations
{
    public partial class AdicionandoCampoCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "ToDoItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "ToDoItems");
        }
    }
}
