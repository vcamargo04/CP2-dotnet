using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_clinicosGerais_CRMId",
                table: "tb_clinicosGerais");

            migrationBuilder.CreateIndex(
                name: "IX_tb_clinicosGerais_CRMId",
                table: "tb_clinicosGerais",
                column: "CRMId",
                unique: true,
                filter: "\"CRMId\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_clinicosGerais_CRMId",
                table: "tb_clinicosGerais");

            migrationBuilder.CreateIndex(
                name: "IX_tb_clinicosGerais_CRMId",
                table: "tb_clinicosGerais",
                column: "CRMId");
        }
    }
}
