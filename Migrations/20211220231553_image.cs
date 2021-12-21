using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeApi.Migrations
{
    public partial class image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataImage",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataImage",
                table: "Pokemons");
        }
    }
}
