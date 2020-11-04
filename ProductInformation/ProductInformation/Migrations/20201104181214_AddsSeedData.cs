using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductInformation.Migrations
{
    public partial class AddsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "ID", "Name" },
                values: new object[] { -1, "Utencil" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "ID", "Name" },
                values: new object[] { -2, "Stationary" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "ID", "Name" },
                values: new object[] { -3, "Paint" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "ID", "CategoryID", "Name" },
                values: new object[,]
                {
                    { -1, -1, "Spoon" },
                    { -2, -1, "Knife" },
                    { -3, -1, "Ladle" },
                    { -4, -2, "Paper" },
                    { -5, -2, "Notebook" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
