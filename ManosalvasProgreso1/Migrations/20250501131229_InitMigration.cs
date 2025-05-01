using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManosalvasProgreso1.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    IdMascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPropietario = table.Column<int>(type: "int", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.IdMascota);
                });

            migrationBuilder.CreateTable(
                name: "PropietarioMascota",
                columns: table => new
                {
                    IdPropietarioMascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MayorEdad = table.Column<bool>(type: "bit", nullable: false),
                    Telefono = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropietarioMascota", x => x.IdPropietarioMascota);
                });

            migrationBuilder.CreateTable(
                name: "VisitaVeterinaria",
                columns: table => new
                {
                    IdVisitaVeterinaria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotivoVisita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiereMedicamento = table.Column<bool>(type: "bit", nullable: false),
                    IdMascota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitaVeterinaria", x => x.IdVisitaVeterinaria);
                    table.ForeignKey(
                        name: "FK_VisitaVeterinaria_Mascota_IdMascota",
                        column: x => x.IdMascota,
                        principalTable: "Mascota",
                        principalColumn: "IdMascota",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitaVeterinaria_IdMascota",
                table: "VisitaVeterinaria",
                column: "IdMascota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropietarioMascota");

            migrationBuilder.DropTable(
                name: "VisitaVeterinaria");

            migrationBuilder.DropTable(
                name: "Mascota");
        }
    }
}
