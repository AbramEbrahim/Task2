using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace task2.Migrations
{
    /// <inheritdoc />
    public partial class NewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_types_BlogId",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "blogs",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_BlogId",
                table: "blogs",
                newName: "IX_blogs_TypeId");

            migrationBuilder.InsertData(
                table: "types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "action" },
                    { 2, "comidy" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_types_TypeId",
                table: "blogs",
                column: "TypeId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_types_TypeId",
                table: "blogs");

            migrationBuilder.DeleteData(
                table: "types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "blogs",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_TypeId",
                table: "blogs",
                newName: "IX_blogs_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_types_BlogId",
                table: "blogs",
                column: "BlogId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
