using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Monitoramento.Ambiental.Migrations
{
    /// <inheritdoc />
    public partial class TableDesastresNaturais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Desastres_Naturais",
                columns: table => new
                {
                    DesastreId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo_Desastre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: true),
                    Resolvido = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Desastres_Naturais", x => x.DesastreId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Desastres_Naturais");
        }
    }
}
