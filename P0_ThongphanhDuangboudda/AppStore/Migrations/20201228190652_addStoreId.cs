using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStore.Migrations
{
    public partial class addStoreId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreLocation",
                table: "OrderHistories",
                newName: "StoreLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreLocationId",
                table: "OrderHistories",
                newName: "StoreLocation");
        }
    }
}
