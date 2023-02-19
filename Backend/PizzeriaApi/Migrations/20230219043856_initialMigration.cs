using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaApi.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToppingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ToppingType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizza_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pizza = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Extra = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Topping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_StoreId",
                table: "Pizza",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_PizzaId",
                table: "PizzaTopping",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId");
            migrationBuilder.InsertData(
                                table: "Topping",
                                columns: new[] { "Id", "ToppingName", "ToppingType", "Price" },
                                values: new object[,] {
                        { 1, "Cheese","Extra",1 },
                        { 2,"Ham","Default",0 },
                        { 3,"Mushrooms","Default",0 },
                        { 4,"Olives","Extra",1 },
                        { 5,"Salami","Extra",1 },
                        { 6,"Capsicum","Extra",1 },
                        { 7,"Chilli","Default",0 },
                        { 8,"Spinach","Default",0 },
                        { 9,"Ricotta","Default",0 },
                        { 10,"Cherry Tomatoes","Default",0 },
                        { 11,"Onion","Default",0 }
                    });

            migrationBuilder.InsertData(
                        table: "Store",
                        columns: new[] { "Id", "StoreName", "Location" },
                        values: new object[,] {
                        { 1, "Preston Pizzeria","Preston" },
                        { 2, "Southbank Pizzeria","Southbank" }
            });

            migrationBuilder.InsertData(
                        table: "Pizza",
                        columns: new[] { "Id", "PizzaName", "StoreId", "Price" },
                        values: new object[,] {
                        { 1, "Capricciosa",1, 20.00 },
                        { 2, "Mexicana",1, 18.00 },
                        { 3, "Margherita",1, 22.00 },
                        { 4, "Capricciosa",2, 25.00 },
                        { 5, "Vegetarian",2, 17.00 }
            });

            migrationBuilder.InsertData(
                        table: "PizzaTopping",
                        columns: new[] { "Id", "PizzaId", "ToppingId", "Qty" },
                        values: new object[,] {
                        { 1, 1, 1, 1 },
                        { 2, 1, 2, 1 },
                        { 3, 1, 3, 1 },
                        { 4, 1, 4, 1 },
                        { 5, 2, 1, 1 },
                        { 6, 2, 5, 1 },
                        { 7, 2, 6, 1 },
                        { 8, 2, 7, 1 },
                        { 9, 3, 1, 1 },
                        { 10, 3, 8, 1 },
                        { 11, 3, 9, 1 },
                        { 12, 3, 10, 1 },
                        { 13, 4, 1, 1 },
                        { 14, 4, 2, 1 },
                        { 15, 4, 3, 1 },
                        { 16, 4, 4, 1 },
                        { 17, 5, 1, 1 },
                        { 18, 5, 3, 1 },
                        { 19, 5, 6, 1 },
                        { 20, 5, 11, 1 },
                        { 21, 5, 4, 1 }
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
