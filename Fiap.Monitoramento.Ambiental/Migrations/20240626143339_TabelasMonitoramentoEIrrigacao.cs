using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Monitoramento.Ambiental.Migrations
{
    /// <inheritdoc />
    public partial class TabelasMonitoramentoEIrrigacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Monitoramento_Ar",
                columns: table => new
                {
                    MonitorarId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Dia_Monitoramento = table.Column<DateTime>(type: "date", nullable: false),
                    Qualidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Monitoramento_Ar", x => x.MonitorarId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Irrigacao",
                columns: table => new
                {
                    IrrigacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Qualidade_Ar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Irrigacao = table.Column<DateTime>(type: "date", nullable: false),
                    Lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MonitoraQualidadeArId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Irrigacao", x => x.IrrigacaoId);
                    table.ForeignKey(
                        name: "FK_TBL_Irrigacao_TBL_Monitoramento_Ar_MonitoraQualidadeArId",
                        column: x => x.MonitoraQualidadeArId,
                        principalTable: "TBL_Monitoramento_Ar",
                        principalColumn: "MonitorarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Irrigacao_MonitoraQualidadeArId",
                table: "TBL_Irrigacao",
                column: "MonitoraQualidadeArId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Irrigacao");

            migrationBuilder.DropTable(
                name: "TBL_Monitoramento_Ar");
        }
    }
}
