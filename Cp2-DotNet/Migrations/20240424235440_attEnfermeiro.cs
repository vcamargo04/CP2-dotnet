using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class attEnfermeiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_enfermeiros_tb_coren_CORENId",
                table: "tb_enfermeiros");

            migrationBuilder.AlterColumn<int>(
                name: "CORENId",
                table: "tb_enfermeiros",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_enfermeiros_tb_coren_CORENId",
                table: "tb_enfermeiros",
                column: "CORENId",
                principalTable: "tb_coren",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_enfermeiros_tb_coren_CORENId",
                table: "tb_enfermeiros");

            migrationBuilder.AlterColumn<int>(
                name: "CORENId",
                table: "tb_enfermeiros",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_enfermeiros_tb_coren_CORENId",
                table: "tb_enfermeiros",
                column: "CORENId",
                principalTable: "tb_coren",
                principalColumn: "Id");
        }
    }
}
