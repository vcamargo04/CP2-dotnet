using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AttPediatra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consultas_tb_clinicosGerais_ClinicoGeralId",
                table: "tb_consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pediatras_tb_crm_CRMId",
                table: "tb_pediatras");

            migrationBuilder.DropIndex(
                name: "IX_tb_pediatras_CRMId",
                table: "tb_pediatras");

            migrationBuilder.DropIndex(
                name: "IX_tb_crm_PediatraId",
                table: "tb_crm");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicoGeralId",
                table: "tb_consultas",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_crm_PediatraId",
                table: "tb_crm",
                column: "PediatraId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consultas_tb_clinicosGerais_ClinicoGeralId",
                table: "tb_consultas",
                column: "ClinicoGeralId",
                principalTable: "tb_clinicosGerais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consultas_tb_clinicosGerais_ClinicoGeralId",
                table: "tb_consultas");

            migrationBuilder.DropIndex(
                name: "IX_tb_crm_PediatraId",
                table: "tb_crm");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicoGeralId",
                table: "tb_consultas",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pediatras_CRMId",
                table: "tb_pediatras",
                column: "CRMId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_crm_PediatraId",
                table: "tb_crm",
                column: "PediatraId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consultas_tb_clinicosGerais_ClinicoGeralId",
                table: "tb_consultas",
                column: "ClinicoGeralId",
                principalTable: "tb_clinicosGerais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_pediatras_tb_crm_CRMId",
                table: "tb_pediatras",
                column: "CRMId",
                principalTable: "tb_crm",
                principalColumn: "CRMId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
