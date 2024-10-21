using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api.Migrations
{
    /// <inheritdoc />
    public partial class perfilAdm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administradores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Perfil",
                value: "Adm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administradores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Perfil",
                value: "Adn");
        }
    }
}
