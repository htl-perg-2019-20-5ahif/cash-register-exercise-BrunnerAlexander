using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.Migrations
{
    public partial class ChangeDatatypeToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLine_Product_ProductId",
                table: "ReceiptLine");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "ReceiptLine",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ReceiptLine",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Receipt",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Product",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLine_Product_ProductId",
                table: "ReceiptLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLine_Product_ProductId",
                table: "ReceiptLine");

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "ReceiptLine",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ReceiptLine",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Receipt",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLine_Product_ProductId",
                table: "ReceiptLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
