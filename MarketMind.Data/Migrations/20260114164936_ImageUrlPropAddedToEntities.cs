using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMind.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrlPropAddedToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "StockNews",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "StockNews");
        }
    }
}
