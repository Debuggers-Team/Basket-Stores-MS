using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket_Store_MS.Migrations
{
    public partial class addFKtocartandpaymenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_CartId",
                table: "PaymentTypes",
                column: "CartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_Carts_CartId",
                table: "PaymentTypes",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_Carts_CartId",
                table: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTypes_CartId",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);
        }
    }
}
