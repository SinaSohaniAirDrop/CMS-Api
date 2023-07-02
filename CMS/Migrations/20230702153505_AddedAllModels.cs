using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "comCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixedCost = table.Column<double>(type: "float", nullable: false),
                    tax = table.Column<double>(type: "float", nullable: false),
                    HQCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsiderFee = table.Column<double>(type: "float", nullable: false),
                    OutsiderFee = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinVal = table.Column<double>(type: "float", nullable: false),
                    MaxVal = table.Column<double>(type: "float", nullable: false),
                    Tariff = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "packagings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinL = table.Column<double>(type: "float", nullable: false),
                    MaxL = table.Column<double>(type: "float", nullable: false),
                    PackagingCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packagings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "volDists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinVol = table.Column<double>(type: "float", nullable: false),
                    MaxVol = table.Column<double>(type: "float", nullable: false),
                    NeighboringProvince = table.Column<double>(type: "float", nullable: false),
                    OtherProvince = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volDists", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comCosts");

            migrationBuilder.DropTable(
                name: "insurances");

            migrationBuilder.DropTable(
                name: "packagings");

            migrationBuilder.DropTable(
                name: "volDists");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "User");
        }
    }
}
