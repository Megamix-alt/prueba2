using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyCRUDCORE.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARGO",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CARGO__6C985625B08276AB", x => x.IdCargo);
                });

            migrationBuilder.CreateTable(
                name: "EMPLEADO",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Correo = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    IdCargo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EMPLEADO__CE6D8B9E886D9E43", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK__EMPLEADO__IdCarg__398D8EEE",
                        column: x => x.IdCargo,
                        principalTable: "CARGO",
                        principalColumn: "IdCargo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLEADO_IdCargo",
                table: "EMPLEADO",
                column: "IdCargo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLEADO");

            migrationBuilder.DropTable(
                name: "CARGO");
        }
    }
}
