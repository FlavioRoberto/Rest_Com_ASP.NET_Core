using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Versao0200 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Login = table.Column<string>(type: "varchar(30)", nullable: false),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
