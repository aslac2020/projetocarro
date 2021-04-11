using Microsoft.EntityFrameworkCore.Migrations;

namespace projetoCarro.Migrations
{
    public partial class atualizaçãoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_id",
                table: "cars",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "cars",
                newName: "_id");
        }
    }
}
