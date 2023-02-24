using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingPizza.EFCore.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Renamepropertyname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Address_AddressId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Orders",
                newName: "DeliveryAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                newName: "IX_Orders_DeliveryAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Address_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Address_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddressId",
                table: "Orders",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                newName: "IX_Orders_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Address_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }
    }
}
