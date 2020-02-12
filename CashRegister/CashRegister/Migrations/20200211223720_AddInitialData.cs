using Microsoft.EntityFrameworkCore.Migrations;

namespace CashRegister.Migrations
{
    public partial class AddInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
