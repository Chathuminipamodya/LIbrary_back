using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Ordered = table.Column<bool>(type: "bit", nullable: false),
                    BookCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_BookCategoryId",
                        column: x => x.BookCategoryId,
                        principalTable: "BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Returned = table.Column<bool>(type: "bit", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinePaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "Id", "Category", "SubCategory" },
                values: new object[,]
                {
                    { 1, "computer", "algorithm" },
                    { 2, "computer", "programming languages" },
                    { 3, "computer", "networking" },
                    { 4, "computer", "hardware" },
                    { 5, "mechanical", "machine" },
                    { 6, "mechanical", "transfer of energy" },
                    { 7, "mathematics", "calculus" },
                    { 8, "mathematics", "algebra" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountStatus", "CreatedOn", "Email", "FirstName", "LastName", "MobileNumber", "Password", "UserType" },
                values: new object[] { 1, "ACTIVE", new DateTime(2025, 7, 1, 13, 28, 12, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Admin", "", "1234567890", "admin1999", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookCategoryId", "Ordered", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Clifford Stein", 1, false, 100f, "Introduction to Algorithm" },
                    { 2, "Clifford Stein", 1, false, 100f, "Introduction to Algorithm" },
                    { 3, "Robert Sedgewick & Kevin Wayne", 1, false, 200f, "Algorithms" },
                    { 4, "Steve Skiena", 1, false, 300f, "The Algorithm Design Manual" },
                    { 5, "Adnan Aziz", 1, false, 400f, "Algorithms For Interviews" },
                    { 6, "Adnan Aziz", 1, false, 400f, "Algorithms For Interviews" },
                    { 7, "Klienberg & Tardos", 1, false, 600f, "Algorithm Design" },
                    { 8, "Eric Matthes", 2, false, 700f, "Python Crash Course: A Hands-On, Project-Based Introduction to Programming" },
                    { 9, "Eric Matthes", 2, false, 700f, "Python Crash Course: A Hands-On, Project-Based Introduction to Programming" },
                    { 10, "Eric Matthes", 2, false, 700f, "Python Crash Course: A Hands-On, Project-Based Introduction to Programming" },
                    { 11, "Kathy Sierra and Bert Bates", 2, false, 1000f, "Head First Java" },
                    { 12, "Brian W. Kernighan, Dennis M. Ritchie", 2, false, 1100f, "C Programming Language" },
                    { 13, "Brian W. Kernighan, Dennis M. Ritchie", 2, false, 1100f, "C Programming Language" },
                    { 14, "Marijn Haverbeke", 2, false, 1200f, "Eloquent JavaScript: A Modern Introduction to Programming" },
                    { 15, "James F Kurose and Keith W Ross", 3, false, 1400f, "A Top-Down Approach: Computer Networking" },
                    { 16, "Rich Seifert and James Edwards", 3, false, 1500f, "The All-New Switch Book (2nd Edition)" },
                    { 17, "Forouzan", 3, false, 1700f, "Data Communications and Networking with TCP/IP Protocol Suite, 6th Edition" },
                    { 18, "Gary Donahue", 3, false, 1800f, "Network Warrior, 2nd Edition" },
                    { 19, "Ramesh Gaonkar", 4, false, 1900f, "Microprocessor Architecture, Programming, and Applications with the 8085 (4th Edition)" },
                    { 20, "Douglas V. Hall", 4, false, 2000f, "Microprocessors and Interfacing: Programming and Hardware (Hardcover)" },
                    { 21, "Kenneth L. Short", 4, false, 2100f, "Embedded Microprocessor Systems Design" },
                    { 22, "Dr. Vibhav Kumar Sachan", 4, false, 2200f, "Digital Electronics & Microprocessor" },
                    { 23, "Xiaocong Fan", 4, false, 2300f, "Real-Time Embedded Systems" },
                    { 24, "Shigley's Mechanical Engineering Design", 5, false, 2500f, "Richard G. Budynas and Keith J. Nisbett" },
                    { 25, "Erik Oberg", 5, false, 2600f, "Machinery's Handbook" },
                    { 26, "Robert L. Norton", 5, false, 2800f, "Machine Design" },
                    { 27, "Robert L. Norton", 5, false, 2800f, "Machine Design" },
                    { 28, "Frank M. White", 6, false, 3000f, "Fluid Mechanics" },
                    { 29, "Claus Borgnakke and Richard E. Sonntag", 6, false, 3100f, "Fundamentals of Thermodynamics" },
                    { 30, "Claus Borgnakke and Richard E. Sonntag", 6, false, 3100f, "Fundamentals of Thermodynamics" },
                    { 31, "James Stewart", 7, false, 3200f, "Calculus: Early Transcendentals" },
                    { 32, "Louis Leithold", 7, false, 3400f, "The Calculus with Analytic Geometry" },
                    { 33, "Robert Kanigel", 8, false, 3600f, "The Man Who Knew Infinity: A Life of the Genius Ramanujan" },
                    { 34, "Robert Kanigel", 8, false, 3600f, "The Man Who Knew Infinity: A Life of the Genius Ramanujan" },
                    { 35, "Stephen Hawking", 8, false, 3700f, "A Brief History of Time" },
                    { 36, "Albert Einstein", 8, false, 3800f, "Relativity: The Special and the General Theory" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BookCategories");
        }
    }
}
