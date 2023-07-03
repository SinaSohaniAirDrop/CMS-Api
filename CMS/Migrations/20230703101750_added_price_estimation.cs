using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Migrations
{
    /// <inheritdoc />
    public partial class added_price_estimation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolDist");

            migrationBuilder.AlterColumn<double>(
                name: "HQCost",
                table: "ComCost",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeighboringProvinceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_provinces_provinces_NeighboringProvinceId",
                        column: x => x.NeighboringProvinceId,
                        principalTable: "provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeightDist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinWeight = table.Column<double>(type: "float", nullable: false),
                    MaxWeight = table.Column<double>(type: "float", nullable: false),
                    NeighboringProvince = table.Column<double>(type: "float", nullable: false),
                    OtherProvince = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightDist", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_provinces_NeighboringProvinceId",
                table: "provinces",
                column: "NeighboringProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightDist_MaxWeight",
                table: "WeightDist",
                column: "MaxWeight",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeightDist_MinWeight",
                table: "WeightDist",
                column: "MinWeight",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "WeightDist");

            migrationBuilder.AlterColumn<string>(
                name: "HQCost",
                table: "ComCost",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "VolDist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxVol = table.Column<double>(type: "float", nullable: false),
                    MinVol = table.Column<double>(type: "float", nullable: false),
                    NeighboringProvince = table.Column<double>(type: "float", nullable: false),
                    OtherProvince = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolDist", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolDist_MaxVol",
                table: "VolDist",
                column: "MaxVol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VolDist_MinVol",
                table: "VolDist",
                column: "MinVol",
                unique: true);
        }
    }
}
