using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_coren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_coren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Diagnostico = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_enfermeiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Setor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    CORENId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_enfermeiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_enfermeiros_tb_coren_CORENId",
                        column: x => x.CORENId,
                        principalTable: "tb_coren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cirurgioes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    CRMId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cirurgioes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_clinicosGerais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    CRMId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clinicosGerais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataConsulta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PacienteId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ClinicoGeralId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_consultas_tb_clinicosGerais_ClinicoGeralId",
                        column: x => x.ClinicoGeralId,
                        principalTable: "tb_clinicosGerais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_consultas_tb_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "tb_pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_crm",
                columns: table => new
                {
                    CRMId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CirurgiaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PediatraId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_crm", x => x.CRMId);
                    table.ForeignKey(
                        name: "FK_tb_crm_tb_cirurgioes_CirurgiaoId",
                        column: x => x.CirurgiaoId,
                        principalTable: "tb_cirurgioes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pediatras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CRMId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pediatras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_pediatras_tb_crm_CRMId",
                        column: x => x.CRMId,
                        principalTable: "tb_crm",
                        principalColumn: "CRMId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cirurgioes_CRMId",
                table: "tb_cirurgioes",
                column: "CRMId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_clinicosGerais_CRMId",
                table: "tb_clinicosGerais",
                column: "CRMId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consultas_ClinicoGeralId",
                table: "tb_consultas",
                column: "ClinicoGeralId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consultas_PacienteId",
                table: "tb_consultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_crm_CirurgiaoId",
                table: "tb_crm",
                column: "CirurgiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_crm_PediatraId",
                table: "tb_crm",
                column: "PediatraId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_enfermeiros_CORENId",
                table: "tb_enfermeiros",
                column: "CORENId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pediatras_CRMId",
                table: "tb_pediatras",
                column: "CRMId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cirurgioes_tb_crm_CRMId",
                table: "tb_cirurgioes",
                column: "CRMId",
                principalTable: "tb_crm",
                principalColumn: "CRMId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_clinicosGerais_tb_crm_CRMId",
                table: "tb_clinicosGerais",
                column: "CRMId",
                principalTable: "tb_crm",
                principalColumn: "CRMId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_crm_tb_pediatras_PediatraId",
                table: "tb_crm",
                column: "PediatraId",
                principalTable: "tb_pediatras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cirurgioes_tb_crm_CRMId",
                table: "tb_cirurgioes");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_pediatras_tb_crm_CRMId",
                table: "tb_pediatras");

            migrationBuilder.DropTable(
                name: "tb_consultas");

            migrationBuilder.DropTable(
                name: "tb_enfermeiros");

            migrationBuilder.DropTable(
                name: "tb_clinicosGerais");

            migrationBuilder.DropTable(
                name: "tb_pacientes");

            migrationBuilder.DropTable(
                name: "tb_coren");

            migrationBuilder.DropTable(
                name: "tb_crm");

            migrationBuilder.DropTable(
                name: "tb_cirurgioes");

            migrationBuilder.DropTable(
                name: "tb_pediatras");
        }
    }
}
