using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Migrations
{
    /// <inheritdoc />
    public partial class added_unique_cons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_volDists",
                table: "volDists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_packagings",
                table: "packagings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_insurances",
                table: "insurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comCosts",
                table: "comCosts");

            migrationBuilder.RenameTable(
                name: "volDists",
                newName: "VolDist");

            migrationBuilder.RenameTable(
                name: "packagings",
                newName: "Packaging");

            migrationBuilder.RenameTable(
                name: "insurances",
                newName: "Insurance");

            migrationBuilder.RenameTable(
                name: "comCosts",
                newName: "ComCost");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolDist",
                table: "VolDist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packaging",
                table: "Packaging",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComCost",
                table: "ComCost",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Packaging_MaxL",
                table: "Packaging",
                column: "MaxL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packaging_MinL",
                table: "Packaging",
                column: "MinL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_MaxVal",
                table: "Insurance",
                column: "MaxVal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_MinVal",
                table: "Insurance",
                column: "MinVal",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VolDist",
                table: "VolDist");

            migrationBuilder.DropIndex(
                name: "IX_VolDist_MaxVol",
                table: "VolDist");

            migrationBuilder.DropIndex(
                name: "IX_VolDist_MinVol",
                table: "VolDist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packaging",
                table: "Packaging");

            migrationBuilder.DropIndex(
                name: "IX_Packaging_MaxL",
                table: "Packaging");

            migrationBuilder.DropIndex(
                name: "IX_Packaging_MinL",
                table: "Packaging");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance");

            migrationBuilder.DropIndex(
                name: "IX_Insurance_MaxVal",
                table: "Insurance");

            migrationBuilder.DropIndex(
                name: "IX_Insurance_MinVal",
                table: "Insurance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComCost",
                table: "ComCost");

            migrationBuilder.RenameTable(
                name: "VolDist",
                newName: "volDists");

            migrationBuilder.RenameTable(
                name: "Packaging",
                newName: "packagings");

            migrationBuilder.RenameTable(
                name: "Insurance",
                newName: "insurances");

            migrationBuilder.RenameTable(
                name: "ComCost",
                newName: "comCosts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_volDists",
                table: "volDists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_packagings",
                table: "packagings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_insurances",
                table: "insurances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comCosts",
                table: "comCosts",
                column: "Id");
        }
    }
}
