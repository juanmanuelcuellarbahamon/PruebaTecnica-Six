using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaTecnica_Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuID);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "usuID", "apellido", "nombre" },
                values: new object[,]
                {
                    { 1m, "Pérez", "Juan" },
                    { 2m, "Gómez", "Ana" },
                    { 3m, "Martínez", "Luis" },
                    { 4m, "López", "Marta" },
                    { 5m, "Ramírez", "Carlos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
