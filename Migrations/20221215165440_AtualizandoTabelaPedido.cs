using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemavendastiadacemy.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTabelaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ValorTotal",
                table: "Pedidos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
