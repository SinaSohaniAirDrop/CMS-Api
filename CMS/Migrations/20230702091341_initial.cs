using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "شناسه کاربر")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "نام و نام خانوادگی"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "ایمیل"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "شماره همراه"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "کلمه عبور"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "آدرس")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
