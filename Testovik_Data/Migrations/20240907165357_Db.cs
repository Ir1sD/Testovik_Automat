using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Testovik_Data.Migrations
{
    /// <inheritdoc />
    public partial class Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brends",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersWithUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<long>(type: "bigint", nullable: false),
                    IdTovar = table.Column<long>(type: "bigint", nullable: false),
                    NameTovar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersWithUsers", x => x.Id);
                });





            migrationBuilder.CreateTable(
                name: "Tovars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBrend = table.Column<long>(type: "bigint", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tovars", x => x.Id);
                });

			    migrationBuilder.InsertData(
                table: "Coins",
                columns: new[] { "Num", "Count" },
                values: new object[,]
                {
	                 {1 , 10},
	                 {2 , 12},
	                 {5 , 6},
	                 {10 , 5}
                });

			migrationBuilder.InsertData(
				table: "Brends",
				columns: new[] { "Name" },
				values: new object[,]
				{
		            { "Coca-Cola"} , { "Pepsi"} , { "Fanta"} , { "Dobry"} , { "Drive"}
				});

			migrationBuilder.InsertData(
				table: "Tovars",
				columns: new[] { "Name", "IdBrend", "LogoPath", "Price" , "Count"},
				values: new object[,]
				{
		            {"Coca-Cola" , 1 , "res/item1.jpg" , 110 , 10},
		            {"Pepsi" , 2 , "res/item2.jpg" , 90, 10},
		            {"Fanta" , 3 , "res/item3.jpg" , 100, 10},
		            {"Dobry" , 4 , "res/item4.jpg" , 113, 10},
		            {"Drive" , 5 , "res/item5.jpg" , 110, 10},
		            {"Coca-Cola" , 1 , "res/item1.jpg" , 110 , 10},
		            {"Pepsi" , 2 , "res/item2.jpg" , 90, 10},
		            {"Fanta" , 3 , "res/item3.jpg" , 100, 10},
		            {"Dobry" , 4 , "res/item4.jpg" , 113 , 10},
		            {"Drive" , 5 , "res/item5.jpg" , 110, 10},
		            {"Coca-Cola" , 1 , "res/item1.jpg" , 110 , 10},
		            {"Pepsi" , 2 , "res/item2.jpg" , 90 , 10},
		            {"Fanta" , 3 , "res/item3.jpg" , 100 , 10},
		            {"Dobry" , 4 , "res/item4.jpg" , 113 , 10},
		            {"Drive" , 5 , "res/item5.jpg" , 110 , 10}
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brends");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrdersWithUsers");

            migrationBuilder.DropTable(
                name: "Tovars");
        }
    }
}
