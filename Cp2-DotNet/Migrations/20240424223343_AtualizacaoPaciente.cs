using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tb_pacientes",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "tb_pacientes");
        }
    }
}
