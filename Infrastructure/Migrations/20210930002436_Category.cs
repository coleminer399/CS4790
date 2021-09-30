using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodTypeID",
                table: "MenuItem",
                newName: "FoodTypeId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "MenuItem",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTypeId",
                table: "MenuItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "MenuItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "MenuItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodTypeID",
                table: "MenuItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_CategoryId",
                table: "MenuItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_FoodTypeId",
                table: "MenuItem",
                column: "FoodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Category_CategoryId",
                table: "MenuItem",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_FoodType_FoodTypeId",
                table: "MenuItem",
                column: "FoodTypeId",
                principalTable: "FoodType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Category_CategoryId",
                table: "MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_FoodType_FoodTypeId",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_CategoryId",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_FoodTypeId",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "FoodTypeID",
                table: "MenuItem");

            migrationBuilder.RenameColumn(
                name: "FoodTypeId",
                table: "MenuItem",
                newName: "FoodTypeID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "MenuItem",
                newName: "CategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTypeID",
                table: "MenuItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "MenuItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
