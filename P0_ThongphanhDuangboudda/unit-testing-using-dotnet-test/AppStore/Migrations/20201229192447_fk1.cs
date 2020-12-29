using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStore.Migrations
{
    public partial class fk1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_Customers_CustomerId",
                table: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistories_CustomerId",
                table: "OrderHistories");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "OrderHistories",
                newName: "CustumerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustumerId",
                table: "OrderHistories",
                newName: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_CustomerId",
                table: "OrderHistories",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_Customers_CustomerId",
                table: "OrderHistories",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
