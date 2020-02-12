using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.Migrations
{
    public partial class productIdToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLine_Product_ProductId",
                table: "ReceiptLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Bananen 1kg", 1.99 },
                    { 2, "Äpfel 1kg", 2.9900000000000002 },
                    { 3, "Trauben Weiß 500g", 2.4900000000000002 },
                    { 4, "Himbeeren 125g", 1.8899999999999999 },
                    { 5, "Karotten 500g", 1.1899999999999999 },
                    { 6, "Eissalat 1 Stück", 0.98999999999999999 },
                    { 7, "Zucchini 1 Stück", 0.98999999999999999 },
                    { 8, "Knoblauch 150g", 2.4900000000000002 },
                    { 9, "Joghurt 200g", 0.48999999999999999 },
                    { 10, "Butter", 2.5899999999999999 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLine_Product_ProductId",
                table: "ReceiptLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptLine_Product_ProductId",
                table: "ReceiptLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Bananen 1kg", 1.99 },
                    { 2, "Äpfel 1kg", 2.9900000000000002 },
                    { 3, "Trauben Weiß 500g", 2.4900000000000002 },
                    { 4, "Himbeeren 125g", 1.8899999999999999 },
                    { 5, "Karotten 500g", 1.1899999999999999 },
                    { 6, "Eissalat 1 Stück", 0.98999999999999999 },
                    { 7, "Zucchini 1 Stück", 0.98999999999999999 },
                    { 8, "Knoblauch 150g", 2.4900000000000002 },
                    { 9, "Joghurt 200g", 0.48999999999999999 },
                    { 10, "Butter", 2.5899999999999999 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptLine_Product_ProductId",
                table: "ReceiptLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
