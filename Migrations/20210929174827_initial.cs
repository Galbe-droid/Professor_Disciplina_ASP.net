using Microsoft.EntityFrameworkCore.Migrations;

namespace TCS_Projeto_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_disciplina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_DISCIPLINA = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CARGA_HORARIA = table.Column<int>(type: "int", nullable: false),
                    FOI_DELETADO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_disciplina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_professor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false),
                    SENHA = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    FOI_EXCLUIDO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_professor", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_disciplina");

            migrationBuilder.DropTable(
                name: "tb_professor");
        }
    }
}
