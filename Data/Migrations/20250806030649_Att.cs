using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeConta.Migrations
{
    /// <inheritdoc />
    public partial class Att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdDevedor",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "IdDivida",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "IdDevedor",
                table: "Dividas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDevedor",
                table: "Pagamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDivida",
                table: "Pagamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDevedor",
                table: "Dividas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
