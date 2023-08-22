using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Microservice.Migrations
{
    public partial class userMicro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageForUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserEntity",
                columns: new[] { "Id", "MessageForUser" },
                values: new object[] { 1, "Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью USER" });

            migrationBuilder.InsertData(
                table: "UserEntity",
                columns: new[] { "Id", "MessageForUser" },
                values: new object[] { 2, "Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью USER(2)" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntity");
        }
    }
}
