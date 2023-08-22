using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Microservice.Migrations
{
    public partial class adminMicro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageForAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdminEntity",
                columns: new[] { "Id", "MessageForAdmin" },
                values: new object[] { 1, "Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью АДМИН" });

            migrationBuilder.InsertData(
                table: "AdminEntity",
                columns: new[] { "Id", "MessageForAdmin" },
                values: new object[] { 2, "Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью АДМИН(2)" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEntity");
        }
    }
}
