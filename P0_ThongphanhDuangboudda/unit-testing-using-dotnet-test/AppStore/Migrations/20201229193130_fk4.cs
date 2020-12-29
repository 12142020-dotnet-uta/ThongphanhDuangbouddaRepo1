using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStore.Migrations
{
    public partial class fk4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderHistories",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_Customers_CustomerId",
                table: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistories_CustomerId",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderHistories");
        }
    }
}
