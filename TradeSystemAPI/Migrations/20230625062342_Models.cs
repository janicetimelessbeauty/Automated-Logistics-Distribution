using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradeSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distributor = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WareName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentralDistance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "NewOrder",
                columns: table => new
                {
                    NewOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewOrder", x => x.NewOrderId);
                    table.ForeignKey(
                        name: "FK_NewOrder_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    NewOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Orders_NewOrder_NewOrderId",
                        column: x => x.NewOrderId,
                        principalTable: "NewOrder",
                        principalColumn: "NewOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderWares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    totalAmount = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderWares_NewOrder_NewOrderId",
                        column: x => x.NewOrderId,
                        principalTable: "NewOrder",
                        principalColumn: "NewOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderWares_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Distributor", "ProductCategory", "ProductDescription", "ProductImgUrl", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { new Guid("53dc9e8c-c3dd-4b5a-8ef0-80535bf66bbb"), 22, "Detox", "Healthy with a rich source of vitamins C", "https://drivemehungry.com/wp-content/uploads/2022/08/korean-banana-milk-5.jpg", "Banana Milk", 20 },
                    { new Guid("569289df-6346-4e75-a15d-923f97cac8ac"), 25, "Dessert", "Perfect for ending your meal with some sweet treats", "https://leitesculinaria.com/wp-content/uploads/2020/01/panna-cotta.jpg", "Panna Cotta", 30 },
                    { new Guid("d048f7ab-5b75-4d37-8f4e-ad939e8dba0a"), 12, "Electric", "Good for your night sleep with coziness and comfort", "https://tamhome.vn/wp-content/uploads/2017/07/IMG_4969.jpg", "Mickey Mouse", 500 }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "CentralDistance", "EstimatedTime", "License", "WareName" },
                values: new object[,]
                {
                    { new Guid("a64608dc-8140-47f2-b886-e3948926ff1a"), "12", 4, "2014", "AUPost" },
                    { new Guid("b7f822ef-493b-4f15-802a-5c75de666e8d"), "21", 3, "2012", "Felix" },
                    { new Guid("e5e31796-666d-4d99-9805-c25ab4343098"), "15", 2, "2005", "FedX" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewOrder_CustomerId",
                table: "NewOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_NewOrderId",
                table: "Orders",
                column: "NewOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWares_NewOrderId",
                table: "OrderWares",
                column: "NewOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWares_WarehouseId",
                table: "OrderWares",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderWares");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "NewOrder");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
