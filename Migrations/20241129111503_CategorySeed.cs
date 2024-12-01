using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NeoStore.Migrations
{
    /// <inheritdoc />
    public partial class CategorySeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProduct_Category_CategoryID",
                table: "CategoryToProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProduct_Products_ProductID",
                table: "CategoryToProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryToProduct",
                table: "CategoryToProduct");

            migrationBuilder.RenameTable(
                name: "CategoryToProduct",
                newName: "CategoryToProducts");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryToProduct_CategoryID",
                table: "CategoryToProducts",
                newName: "IX_CategoryToProducts_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryToProducts",
                table: "CategoryToProducts",
                columns: new[] { "ProductID", "CategoryID" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Category 1", "Car" },
                    { 2, "Category 2", "Phone" },
                    { 3, "Category 3", "Book" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Book");

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProducts_Category_CategoryID",
                table: "CategoryToProducts",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProducts_Products_ProductID",
                table: "CategoryToProducts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProducts_Category_CategoryID",
                table: "CategoryToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProducts_Products_ProductID",
                table: "CategoryToProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryToProducts",
                table: "CategoryToProducts");

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "CategoryToProducts",
                newName: "CategoryToProduct");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryToProducts_CategoryID",
                table: "CategoryToProduct",
                newName: "IX_CategoryToProduct_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryToProduct",
                table: "CategoryToProduct",
                columns: new[] { "ProductID", "CategoryID" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Phone");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Phone");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Phone");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProduct_Category_CategoryID",
                table: "CategoryToProduct",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProduct_Products_ProductID",
                table: "CategoryToProduct",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
