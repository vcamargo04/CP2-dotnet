using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AttClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_clinicosGerais_tb_crm_CRMId",
                table: "tb_clinicosGerais");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_enfermeiros_tb_coren_CORENId",
                table: "tb_enfermeiros");

            migrationBuilder.AlterColumn<int>(
                name: "CRMId",
                table: "tb_pediatras",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "CORENId",
                table: "tb_enfermeiros",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "CRMId",
                table: "tb_clinicosGerais",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "CRMId",
                table: "tb_cirurgioes",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_clinicosGerais_tb_crm_CRMId",
                table: "tb_clinicosGerais",
                column: "CRMId",
                principalTable: "tb_crm",
                principalColumn: "CRMId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_enfermeiros_tb_coren_CORENId",
                table: "tb_enfermeiros",
                column: "CORENId",
                principalTable: "tb_coren",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_clinicosGerais_tb_crm_CRMId",
                table: "tb_clinicosGerais");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_enfermeiros_tb_coren_CORENId",
                table: "tb_enfermeiros");

            migrationBuilder.AlterColumn<int>(
                name: "CRMId",
                table: "tb_pediatras",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CORENId",
                table: "tb_enfermeiros",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CRMId",
                table: "tb_clinicosGerais",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CRMId",
                table: "tb_cirurgioes",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_clinicosGerais_tb_crm_CRMId",
                table: "tb_clinicosGerais",
                column: "CRMId",
                principalTable: "tb_crm",
                principalColumn: "CRMId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_enfermeiros_tb_coren_CORENId",
                table: "tb_enfermeiros",
                column: "CORENId",
                principalTable: "tb_coren",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
