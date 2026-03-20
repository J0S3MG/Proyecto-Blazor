using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ejemplo_Blazor_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reunion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Desc = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Virtual = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reunion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "reunion",
                columns: new[] { "Id", "Desc", "Virtual" },
                values: new object[] { 1, "Revisión de arquitectura: Implementación de patrón MVVM en el módulo de reuniones.", true });

            migrationBuilder.InsertData(
                table: "reunion",
                columns: new[] { "Id", "Desc" },
                values: new object[,]
                {
                    { 2, "Sincronización de equipo: Discusión sobre la migración de SQL Server a PostgreSQL." },
                    { 3, "Capacitación técnica: Mejores prácticas para el uso de Dependency Injection en .NET 8." }
                });

            migrationBuilder.InsertData(
                table: "reunion",
                columns: new[] { "Id", "Desc", "Virtual" },
                values: new object[] { 4, "Daily meeting: Seguimiento de tareas del Proyecto Verano y despliegue en Railway.", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reunion");
        }
    }
}
