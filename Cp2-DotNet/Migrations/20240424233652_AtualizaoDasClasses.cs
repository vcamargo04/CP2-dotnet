using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaoDasClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cirurgioes_tb_crm_CRMId",
                table: "tb_cirurgioes");

            migrationBuilder.DropIndex(
                name: "IX_tb_crm_CirurgiaoId",
                table: "tb_crm");

            migrationBuilder.DropIndex(
                name: "IX_tb_cirurgioes_CRMId",
                table: "tb_cirurgioes");

            migrationBuilder.CreateIndex(
                name: "IX_tb_crm_CirurgiaoId",
                table: "tb_crm",
                column: "CirurgiaoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_crm_CirurgiaoId",
                table: "tb_crm");

            migrationBuilder.CreateIndex(
                name: "IX_tb_crm_CirurgiaoId",
                table: "tb_crm",
                column: "CirurgiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cirurgioes_CRMId",
                table: "tb_cirurgioes",
                column: "CRMId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cirurgioes_tb_crm_CRMId",
                table: "tb_cirurgioes",
                column: "CRMId",
                principalTable: "tb_crm",
                principalColumn: "CRMId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
