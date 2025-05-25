using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UPdateWarehouseProdudctRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Warehouses_WarehouseLocationId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "WarehouseLocationId",
                table: "Products",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_WarehouseLocationId",
                table: "Products",
                newName: "IX_Products_WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Warehouses_WarehouseId",
                table: "Products",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Warehouses_WarehouseId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Products",
                newName: "WarehouseLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_WarehouseId",
                table: "Products",
                newName: "IX_Products_WarehouseLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Warehouses_WarehouseLocationId",
                table: "Products",
                column: "WarehouseLocationId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
