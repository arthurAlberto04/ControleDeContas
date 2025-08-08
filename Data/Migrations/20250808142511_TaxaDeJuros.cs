using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeConta.Migrations
{
    /// <inheritdoc />
    public partial class TaxaDeJuros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "taxaDeJuros",
                table: "Dividas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "taxaDeJuros",
                table: "Dividas");
        }
    }
}
