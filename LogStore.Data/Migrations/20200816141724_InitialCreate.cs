using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogStore.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<decimal>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemType",
                columns: table => new
                {
                    OrderItemTypeID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    QuantityProduct = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemType", x => x.OrderItemTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    OrderItemTypeID = table.Column<long>(nullable: false),
                    OrderID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_OrderItemType_OrderItemTypeID",
                        column: x => x.OrderItemTypeID,
                        principalTable: "OrderItemType",
                        principalColumn: "OrderItemTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderSubItem",
                columns: table => new
                {
                    OrderSubItemID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderItemID = table.Column<long>(nullable: false),
                    ProductID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSubItem", x => x.OrderSubItemID);
                    table.ForeignKey(
                        name: "FK_OrderSubItem_OrderItem_OrderItemID",
                        column: x => x.OrderItemID,
                        principalTable: "OrderItem",
                        principalColumn: "OrderItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSubItem_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderItemType",
                columns: new[] { "OrderItemTypeID", "Description", "Name" },
                values: new object[] { 1L, "Pizza grande de 8 fatias com um único sabor", "Pizza Grande (8 Fatias)" });

            migrationBuilder.InsertData(
                table: "OrderItemType",
                columns: new[] { "OrderItemTypeID", "Description", "Name", "QuantityProduct" },
                values: new object[] { 2L, "Pizza grande de 8 fatias com dois sabores", "Pizza Grande (8 Fatias) - 2 Sabores", 2 });

            migrationBuilder.InsertData(
                table: "OrderItemType",
                columns: new[] { "OrderItemTypeID", "Description", "Name" },
                values: new object[] { 3L, "Pizza grande de 4 fatias com um único sabor", "Pizza Broto (4 Fatias)" });

            migrationBuilder.InsertData(
                table: "OrderItemType",
                columns: new[] { "OrderItemTypeID", "Description", "Name", "QuantityProduct" },
                values: new object[] { 4L, "Pizza grande de 4 fatias com dois sabaores", "Pizza Broto (4 Fatias) - 2 Sabores", 2 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Description", "Name", "Value" },
                values: new object[] { 1L, "Molho de tomate coberto por três tipo de queijo", "3 Queijos", 50m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Description", "Name", "Value" },
                values: new object[] { 2L, "Molho de tomate coberto de frango com requeijão", "Frango com Requeijão", 59.99m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Description", "Name", "Value" },
                values: new object[] { 3L, "Molho de tomate coberto por queijo mussarela", "Mussarela", 42.50m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Description", "Name", "Value" },
                values: new object[] { 4L, "Molho de tomate coberto por calabresa e cebola", "Calabresa", 42.50m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Description", "Name", "Value" },
                values: new object[] { 5L, "Molho de tomate coberto por pepperoni", "Pepperoni", 55m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Description", "Name", "Value" },
                values: new object[] { 6L, "Molho de tomate coberto por mussarela, pressunto, ovo e banco", "Portuguesa ", 45m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Description", "Name", "Value" },
                values: new object[] { 7L, "Molho de tomate coberto por mussarela, Tomate e ervilha", "Veggie  ", 59.99m });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderItemTypeID",
                table: "OrderItem",
                column: "OrderItemTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSubItem_OrderItemID",
                table: "OrderSubItem",
                column: "OrderItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSubItem_ProductID",
                table: "OrderSubItem",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSubItem");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderItemType");
        }
    }
}
