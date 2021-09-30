using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Category2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Category_CategoryId",
                table: "MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_FoodType_FoodTypeId",
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

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_FoodTypeId",
                table: "MenuItem",
                newName: "IX_MenuItem_FoodTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_CategoryId",
                table: "MenuItem",
                newName: "IX_MenuItem_CategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTypeID",
                table: "MenuItem",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "MenuItem",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Category_CategoryID",
                table: "MenuItem",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_FoodType_FoodTypeID",
                table: "MenuItem",
                column: "FoodTypeID",
                principalTable: "FoodType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Category_CategoryID",
                table: "MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_FoodType_FoodTypeID",
                table: "MenuItem");

            migrationBuilder.RenameColumn(
                name: "FoodTypeID",
                table: "MenuItem",
                newName: "FoodTypeId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "MenuItem",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_FoodTypeID",
                table: "MenuItem",
                newName: "IX_MenuItem_FoodTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_CategoryID",
                table: "MenuItem",
                newName: "IX_MenuItem_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTypeId",
                table: "MenuItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "MenuItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodTypeID",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
