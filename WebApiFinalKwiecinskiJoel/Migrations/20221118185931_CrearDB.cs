using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiFinalKwiecinskiJoel.Migrations
{
    public partial class CrearDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    HospitalCod = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Direccion = table.Column<string>(type: "varchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(50)", nullable: true),
                    Num_Cama = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.HospitalCod);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: true),
                    Especialidad = table.Column<string>(type: "varchar(50)", nullable: true),
                    HospitalCod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.No);
                    table.ForeignKey(
                        name: "FK_Doctor_Hospital_HospitalCod",
                        column: x => x.HospitalCod,
                        principalTable: "Hospital",
                        principalColumn: "HospitalCod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_HospitalCod",
                table: "Doctor",
                column: "HospitalCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Hospital");
        }
    }
}
