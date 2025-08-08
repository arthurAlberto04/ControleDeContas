using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeConta.Migrations
{
    /// <inheritdoc />
    public partial class Comecando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dividas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<float>(type: "real", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataDeInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    devedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dividas_Devedores_devedorId",
                        column: x => x.devedorId,
                        principalTable: "Devedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dividaId = table.Column<int>(type: "int", nullable: false),
                    devedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Devedores_devedorId",
                        column: x => x.devedorId,
                        principalTable: "Devedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Dividas_dividaId",
                        column: x => x.dividaId,
                        principalTable: "Dividas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dividas_devedorId",
                table: "Dividas",
                column: "devedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_devedorId",
                table: "Pagamentos",
                column: "devedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_dividaId",
                table: "Pagamentos",
                column: "dividaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Dividas");

            migrationBuilder.DropTable(
                name: "Devedores");
        }
    }
}
