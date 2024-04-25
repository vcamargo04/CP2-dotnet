using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AtualizadoPediatra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "tb_pediatras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "tb_pediatras",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
