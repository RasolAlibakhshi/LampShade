using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastractuer.Migrations
{
    /// <inheritdoc />
    public partial class renameopreationtoInventoryOpreations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opreations");

            migrationBuilder.CreateTable(
                name: "InventoryOpreations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationType = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    OperatorID = table.Column<long>(type: "bigint", nullable: false),
                    OprationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    InventoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOpreations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryOpreations_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpreations_InventoryID",
                table: "InventoryOpreations",
                column: "InventoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryOpreations");

            migrationBuilder.CreateTable(
                name: "Opreations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryID = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationType = table.Column<bool>(type: "bit", nullable: false),
                    OperatorID = table.Column<long>(type: "bigint", nullable: false),
                    OprationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opreations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Opreations_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opreations_InventoryID",
                table: "Opreations",
                column: "InventoryID");
        }
    }
}
