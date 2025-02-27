using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddTblProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0ded9624-32f6-43bd-a2ca-a53c3034fb96"), "Budweiser", 3.50m, 1, null },
                    { new Guid("12a1a395-dc65-4e6c-b7f8-13e606982650"), "Michelob", 4.50m, 1, null },
                    { new Guid("87d2999d-6fe9-49bb-8a96-5aeea262439a"), "Corona", 4.25m, 1, null },
                    { new Guid("8a965afd-91cd-464e-9313-1df1cbd8ae1c"), "Heineken", 4.00m, 1, null },
                    { new Guid("e960583f-985f-4a2c-99b6-74f398203db4"), "Original", 5.00m, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
