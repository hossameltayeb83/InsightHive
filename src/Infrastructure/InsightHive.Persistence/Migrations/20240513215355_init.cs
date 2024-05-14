using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsightHive.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFilter",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    FiltersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFilter", x => new { x.CategoriesId, x.FiltersId });
                    table.ForeignKey(
                        name: "FK_CategoryFilter_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFilter_Filters_FiltersId",
                        column: x => x.FiltersId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FilterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviewers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BadgeReviewer",
                columns: table => new
                {
                    BadgesId = table.Column<int>(type: "int", nullable: false),
                    ReviewersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadgeReviewer", x => new { x.BadgesId, x.ReviewersId });
                    table.ForeignKey(
                        name: "FK_BadgeReviewer_Badges_BadgesId",
                        column: x => x.BadgesId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BadgeReviewer_Reviewers_ReviewersId",
                        column: x => x.ReviewersId,
                        principalTable: "Reviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => new { x.Image, x.BusinessId });
                    table.ForeignKey(
                        name: "FK_Attachments_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsReaction",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    ReactionId = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsReaction", x => new { x.ReviewId, x.ReactionId, x.ReviewerId });
                    table.ForeignKey(
                        name: "FK_ReviewsReaction_Reactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewsReaction_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewsReaction_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Badges/1_img.png", "TopContributor" },
                    { 2, "Badges/2_img.png", "CommentsMaster" },
                    { 3, "Badges/3_img.png", "ReviewsEmperor" },
                    { 4, "Badges/4_img.png", "ReactionsLord" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Clothing" },
                    { 2, "Movies" },
                    { 3, "Kids" },
                    { 4, "Beauty" },
                    { 5, "Home" },
                    { 6, "Outdoors" },
                    { 7, "Automotive" },
                    { 8, "Beauty" }
                });

            migrationBuilder.InsertData(
                table: "Filters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Music & Automotive" },
                    { 2, "Computers, Games & Shoes" },
                    { 3, "Electronics, Home & Baby" },
                    { 4, "Music & Computers" },
                    { 5, "Clothing" },
                    { 6, "Automotive" },
                    { 7, "Toys, Toys & Electronics" },
                    { 8, "Kids & Jewelery" },
                    { 9, "Beauty & Jewelery" },
                    { 10, "Kids, Grocery & Jewelery" }
                });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Like" },
                    { 2, "Dislike" },
                    { 3, "Helpful" },
                    { 4, "Exciting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "FilterId" },
                values: new object[,]
                {
                    { 1, "Virginia", 1 },
                    { 2, "indigo", 1 },
                    { 3, "back up", 1 },
                    { 4, "Automated", 2 },
                    { 5, "Rubber", 2 },
                    { 6, "driver", 3 },
                    { 7, "brand", 3 },
                    { 8, "Refined", 4 },
                    { 9, "Sleek Granite Bike", 4 },
                    { 10, "SDR", 4 },
                    { 11, "copy", 4 },
                    { 12, "strategic", 4 },
                    { 13, "Concrete", 5 },
                    { 14, "Turnpike", 5 },
                    { 15, "Corporate", 6 },
                    { 16, "feed", 6 },
                    { 17, "concept", 6 },
                    { 18, "Peso Uruguayo", 6 },
                    { 19, "Ports", 6 },
                    { 20, "Bedfordshire", 7 },
                    { 21, "Pennsylvania", 7 },
                    { 22, "standardization", 7 },
                    { 23, "withdrawal", 7 },
                    { 24, "Checking Account", 8 },
                    { 25, "port", 8 },
                    { 26, "Ergonomic", 8 },
                    { 27, "Developer", 9 },
                    { 28, "Incredible Plastic Chicken", 9 },
                    { 29, "Auto Loan Account", 9 },
                    { 30, "transmitting", 10 },
                    { 31, "alarm", 10 },
                    { 32, "scalable", 10 },
                    { 33, "Human", 10 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Home" },
                    { 2, 1, "Sports" },
                    { 3, 1, "Kids" },
                    { 4, 1, "Tools" },
                    { 5, 2, "Industrial" },
                    { 6, 2, "Home" },
                    { 7, 2, "Industrial" },
                    { 8, 2, "Health" },
                    { 9, 2, "Automotive" },
                    { 10, 3, "Books" },
                    { 11, 3, "Shoes" },
                    { 12, 3, "Kids" },
                    { 13, 4, "Health" },
                    { 14, 4, "Health" },
                    { 15, 4, "Automotive" },
                    { 16, 4, "Electronics" },
                    { 17, 4, "Toys" },
                    { 18, 5, "Music" },
                    { 19, 5, "Outdoors" },
                    { 20, 5, "Beauty" },
                    { 21, 6, "Grocery" },
                    { 22, 6, "Baby" },
                    { 23, 7, "Electronics" },
                    { 24, 7, "Sports" },
                    { 25, 7, "Baby" },
                    { 26, 7, "Movies" },
                    { 27, 8, "Home" },
                    { 28, 8, "Industrial" },
                    { 29, 8, "Industrial" },
                    { 30, 8, "Toys" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "owner1@gmail.com", "Alysa.Prosacco", "password", 1 },
                    { 2, "owner2@gmail.com", "Marianna54", "password", 1 },
                    { 3, "owner3@gmail.com", "Kyra_Tremblay73", "password", 1 },
                    { 4, "owner4@gmail.com", "Janet88", "password", 1 },
                    { 5, "reviewer5@gmail.com", "Manuel_Stehr", "password", 2 },
                    { 6, "owner6@gmail.com", "Domenico_Pagac", "password", 1 },
                    { 7, "reviewer7@gmail.com", "Lindsay.Miller", "password", 2 },
                    { 8, "owner8@gmail.com", "Forrest67", "password", 1 },
                    { 9, "owner9@gmail.com", "Shawn_Nikolaus64", "password", 1 },
                    { 10, "reviewer10@gmail.com", "Olaf92", "password", 2 },
                    { 11, "reviewer11@gmail.com", "Arjun.Buckridge", "password", 2 },
                    { 12, "owner12@gmail.com", "Tina54", "password", 1 },
                    { 13, "owner13@gmail.com", "Heath98", "password", 1 },
                    { 14, "reviewer14@gmail.com", "Meda75", "password", 2 },
                    { 15, "owner15@gmail.com", "Wilford.Dietrich", "password", 1 },
                    { 16, "owner16@gmail.com", "Wilhelmine.Nienow", "password", 1 },
                    { 17, "reviewer17@gmail.com", "Leonor55", "password", 2 },
                    { 18, "reviewer18@gmail.com", "Lucinda_Stracke50", "password", 2 },
                    { 19, "reviewer19@gmail.com", "Sidney_Schuster12", "password", 2 },
                    { 20, "reviewer20@gmail.com", "Monserrate_Weber25", "password", 2 },
                    { 21, "reviewer21@gmail.com", "Connie.Conn", "password", 2 },
                    { 22, "owner22@gmail.com", "Francisco4", "password", 1 },
                    { 23, "owner23@gmail.com", "Camilla_Bahringer", "password", 1 },
                    { 24, "owner24@gmail.com", "Jewel.Beahan", "password", 1 },
                    { 25, "reviewer25@gmail.com", "Carrie55", "password", 2 },
                    { 26, "reviewer26@gmail.com", "Narciso.Witting", "password", 2 },
                    { 27, "owner27@gmail.com", "Clotilde39", "password", 1 },
                    { 28, "owner28@gmail.com", "Zoila_Hudson10", "password", 1 },
                    { 29, "reviewer29@gmail.com", "Callie_Legros", "password", 2 },
                    { 30, "reviewer30@gmail.com", "Tremayne.Terry45", "password", 2 },
                    { 31, "owner31@gmail.com", "Juwan84", "password", 1 },
                    { 32, "reviewer32@gmail.com", "Aida.Hilll", "password", 2 },
                    { 33, "owner33@gmail.com", "Nathanial86", "password", 1 },
                    { 34, "reviewer34@gmail.com", "Dorothy_Dibbert", "password", 2 },
                    { 35, "owner35@gmail.com", "Zachariah_Dach", "password", 1 },
                    { 36, "owner36@gmail.com", "Rahul.Ankunding22", "password", 1 },
                    { 37, "reviewer37@gmail.com", "Preston15", "password", 2 },
                    { 38, "reviewer38@gmail.com", "Willow_Koch91", "password", 2 },
                    { 39, "owner39@gmail.com", "Juliana.Wisoky", "password", 1 },
                    { 40, "reviewer40@gmail.com", "Julio8", "password", 2 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BusinessId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 6 },
                    { 6, 6, 8 },
                    { 7, 7, 9 },
                    { 8, 8, 12 },
                    { 9, 9, 13 },
                    { 10, 10, 15 },
                    { 11, 11, 16 },
                    { 12, 12, 22 },
                    { 13, 13, 23 },
                    { 14, 14, 24 },
                    { 15, 15, 27 },
                    { 16, 16, 28 },
                    { 17, 17, 31 },
                    { 18, 18, 33 },
                    { 19, 19, 35 },
                    { 20, 20, 36 },
                    { 21, 21, 39 }
                });

            migrationBuilder.InsertData(
                table: "Reviewers",
                columns: new[] { "Id", "Age", "Gender", "Image", "UserId" },
                values: new object[,]
                {
                    { 1, 95, 2, "Review\\1_img.png", 5 },
                    { 2, 36, 2, "Review\\2_img.png", 7 },
                    { 3, 40, 0, "Review\\3_img.png", 10 },
                    { 4, 68, 1, "Review\\4_img.png", 11 },
                    { 5, 37, 0, "Review\\5_img.png", 14 },
                    { 6, 57, 0, "Review\\6_img.png", 17 },
                    { 7, 37, 1, "Review\\7_img.png", 18 },
                    { 8, 92, 0, "Review\\8_img.png", 19 },
                    { 9, 74, 0, "Review\\9_img.png", 20 },
                    { 10, 41, 0, "Review\\10_img.png", 21 },
                    { 11, 80, 1, "Review\\11_img.png", 25 },
                    { 12, 33, 1, "Review\\12_img.png", 26 },
                    { 13, 87, 0, "Review\\13_img.png", 29 },
                    { 14, 41, 0, "Review\\14_img.png", 30 },
                    { 15, 23, 1, "Review\\15_img.png", 32 },
                    { 16, 75, 1, "Review\\16_img.png", 34 },
                    { 17, 77, 0, "Review\\17_img.png", 37 },
                    { 18, 38, 2, "Review\\18_img.png", 38 },
                    { 19, 81, 1, "Review\\19_img.png", 40 }
                });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "Description", "Logo", "Name", "OwnerId", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, "Perspiciatis accusantium quaerat dolorem numquam voluptatem qui. Aut consectetur sint similique id. Voluptatibus asperiores tenetur perferendis voluptatem eius voluptatibus.", "Business\\1_img.png", "Bednar and Sons", 1, 4 },
                    { 2, "Nemo accusamus sed enim et nulla nostrum dolorem facere. Quia culpa et enim sit laboriosam consectetur dolores accusantium. Reprehenderit perspiciatis accusamus est architecto nam. Ducimus ut in asperiores quo vero ut qui adipisci dignissimos. Harum omnis nostrum enim.", "Business\\2_img.png", "Will, Leannon and Heidenreich", 2, 10 },
                    { 3, "Minus laborum rerum rem. Aperiam labore beatae possimus quam dignissimos dolorem. Sapiente qui aliquid. Et quam minus dolor illo fuga cupiditate magnam et itaque.", "Business\\3_img.png", "Cole, Gusikowski and Doyle", 3, 6 },
                    { 4, "Aut aspernatur perspiciatis sit autem tempora veritatis ut omnis cumque. Veritatis velit et aperiam voluptatibus at perspiciatis sit explicabo. Omnis minima hic sint enim. Iusto ut possimus omnis accusamus eum. Iure aliquid qui qui placeat. Quibusdam voluptatem temporibus fuga odio.", "Business\\4_img.png", "Robel - Waelchi", 4, 10 },
                    { 5, "Impedit doloremque inventore optio saepe aperiam nihil deleniti molestiae. Aliquid numquam aut explicabo rerum incidunt magni sequi quasi corporis. Culpa ut assumenda voluptatem veritatis sed. Sint quas quos sunt sed qui quia. Sint sapiente hic sunt debitis. Qui voluptates molestias similique rerum.", "Business\\5_img.png", "Von, Hessel and Heathcote", 5, 7 },
                    { 6, "Eius ea ab suscipit reiciendis et laboriosam voluptas soluta. Eos maiores omnis fugit occaecati fugit et ut consequatur nobis. Et numquam neque ducimus quo deserunt.", "Business\\6_img.png", "Hansen - Harris", 6, 7 },
                    { 7, "Soluta dolor eligendi adipisci quia ea. Et libero repellendus quae quam corrupti nemo. Eaque voluptatem excepturi quaerat. Voluptate hic sed occaecati. Error sit saepe.", "Business\\7_img.png", "Hudson, Funk and Gerlach", 7, 12 },
                    { 8, "Libero dignissimos ut temporibus ea. Ut architecto et rerum ad sed. Voluptatem enim nisi architecto. Quod itaque odio harum consectetur soluta vero sed aliquid. Voluptas soluta sit assumenda reiciendis neque. Et tempore officiis dignissimos quia sed expedita ut repellat.", "Business\\8_img.png", "Ward, Dicki and Will", 8, 2 },
                    { 9, "Ipsam debitis odit et nesciunt ad magnam accusamus fugit. Deserunt laborum aut id. Tenetur omnis eaque repellat omnis sequi aut. Ducimus et incidunt veniam quas.", "Business\\9_img.png", "Cartwright and Sons", 9, 6 },
                    { 10, "Ut ea consequatur vitae omnis. Qui sapiente quia sed repudiandae est non quo expedita sapiente. Aliquid illo ullam. Beatae qui dolor hic ut voluptatibus veritatis et facilis. Iure veniam iste ut accusantium eum nam.", "Business\\10_img.png", "Rosenbaum and Sons", 10, 1 },
                    { 11, "Quo exercitationem ipsam iure laboriosam ipsam ut cumque amet. Alias ipsam perferendis quibusdam consequuntur cumque ab aspernatur recusandae et. Exercitationem est neque unde quos non qui dolor ut. Commodi voluptas quia doloremque ipsa molestias amet fugit minus. Rem repellat vero at quam provident aut et. Aut enim et quis ipsa nemo perferendis odio qui.", "Business\\11_img.png", "Grady, Hessel and Barton", 11, 13 },
                    { 12, "Modi minima quos est. Voluptatem fugiat occaecati repellendus qui placeat voluptatibus odio et fugiat. Est ex ipsa sint rem id itaque libero sit nemo. Enim commodi molestiae et. Quae architecto ratione reiciendis consequatur similique sunt tempora.", "Business\\12_img.png", "Metz LLC", 12, 10 },
                    { 13, "Aliquam fuga in dolor sed nemo. Similique sunt inventore ut nihil occaecati expedita. Et laudantium nisi id labore. Corporis aut repellat dolor.", "Business\\13_img.png", "Wuckert LLC", 13, 17 },
                    { 14, "Officiis odit quam in porro ex nesciunt. Vitae quo nihil saepe sunt nisi facere est porro. Ipsa veritatis iste sapiente voluptate delectus odit.", "Business\\14_img.png", "Wisozk, Bergstrom and Parisian", 14, 9 },
                    { 15, "Sed adipisci inventore voluptatem ipsa consequuntur ut ipsa. Labore est sunt delectus explicabo. Vel excepturi aut et dolores asperiores.", "Business\\15_img.png", "Yost, Beahan and West", 15, 30 },
                    { 16, "Odit nemo eligendi quasi eos quia voluptatem sed. Sit consequatur necessitatibus delectus ut. Ipsa enim quae ullam esse eaque nihil nisi tenetur et. Tempora iure accusantium ipsam ratione est vitae excepturi voluptatem saepe.", "Business\\16_img.png", "Smith, Schowalter and Schaden", 16, 2 },
                    { 17, "Illum sed quibusdam ut quas recusandae provident dolore. Doloremque asperiores minus est. Culpa enim dolore ea. Quidem iusto ipsa officia. Consequuntur aut sunt non blanditiis laboriosam. Culpa qui est nostrum vitae.", "Business\\17_img.png", "Auer, O'Reilly and Hartmann", 17, 11 },
                    { 18, "Modi fuga itaque eos repudiandae vero hic cum sint et. Omnis ducimus ut optio aperiam similique. Et vel maxime minus aut sit.", "Business\\18_img.png", "Stracke - Wolff", 18, 3 },
                    { 19, "Nihil temporibus quia ut. Quo libero id dolorem rem sed velit vero aut vel. Expedita qui asperiores aperiam unde fugit aperiam et sit. Ipsam doloremque velit quas eligendi perferendis sint delectus perferendis. Rerum sed tempore odio facere voluptatem velit tenetur.", "Business\\19_img.png", "Bahringer - Predovic", 19, 27 },
                    { 20, "Omnis quam veniam et enim qui nam qui. Enim placeat dignissimos neque culpa suscipit est. Consectetur repudiandae qui corporis. Qui quo ut exercitationem ab qui. Totam doloribus est voluptatem qui. Qui quis quidem.", "Business\\20_img.png", "Corkery - Lehner", 20, 29 },
                    { 21, "Explicabo qui ducimus. Eos unde modi ullam occaecati deserunt nesciunt cumque. Et sit quae cumque autem aut. Vitae voluptate magnam dolorem quod id tempora quia. Iusto odit perferendis.", "Business\\21_img.png", "Morissette and Sons", 21, 10 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BusinessId", "Content", "CreatedDate", "Image", "LastModifiedDate", "Rate", "ReviewerId" },
                values: new object[,]
                {
                    { 1, 2, "I tried to pinch it but got peanut all over it.", new DateTime(2024, 4, 16, 21, 41, 35, 280, DateTimeKind.Unspecified).AddTicks(729), "Review\\1_img.png", null, 1.7161634f, 1 },
                    { 2, 1, "My demon loves to play with it.", new DateTime(2024, 5, 6, 20, 10, 52, 247, DateTimeKind.Unspecified).AddTicks(6347), "Review\\2_img.png", null, 4.2905493f, 1 },
                    { 3, 3, "My bass loves to play with it.", new DateTime(2024, 4, 25, 13, 56, 13, 938, DateTimeKind.Unspecified).AddTicks(9978), "Review\\3_img.png", null, 4.5913835f, 1 },
                    { 4, 2, "one of my hobbies is skateboarding. and when i'm skateboarding this works great.", new DateTime(2024, 5, 9, 16, 10, 25, 435, DateTimeKind.Unspecified).AddTicks(431), "Review\\4_img.png", null, 2.5215755f, 1 },
                    { 5, 1, "I saw one of these in Haiti and I bought one.", new DateTime(2024, 4, 29, 22, 57, 12, 115, DateTimeKind.Unspecified).AddTicks(3200), "Review\\5_img.png", null, 2.8636088f, 1 },
                    { 6, 5, "talk about sadness!", new DateTime(2024, 5, 13, 0, 39, 37, 61, DateTimeKind.Unspecified).AddTicks(6352), "Review\\6_img.png", null, 2.0246062f, 2 },
                    { 7, 5, "one of my hobbies is theater. and when i'm acting this works great.", new DateTime(2024, 4, 15, 0, 35, 34, 952, DateTimeKind.Unspecified).AddTicks(2696), "Review\\7_img.png", null, 1.9881359f, 2 },
                    { 8, 5, "The box this comes in is 4 yard by 5 kilometer and weights 11 pound!", new DateTime(2024, 5, 3, 18, 27, 29, 670, DateTimeKind.Unspecified).AddTicks(595), "Review\\8_img.png", null, 1.7436033f, 2 },
                    { 9, 2, "I tried to maim it but got nectarine all over it.", new DateTime(2024, 4, 23, 11, 51, 30, 91, DateTimeKind.Unspecified).AddTicks(8398), "Review\\9_img.png", null, 1.3999183f, 3 },
                    { 10, 7, "My co-worker Merwin has one of these. He says it looks bubbly.", new DateTime(2024, 5, 1, 1, 50, 25, 170, DateTimeKind.Unspecified).AddTicks(3030), "Review\\10_img.png", null, 1.920838f, 3 },
                    { 11, 3, "one of my hobbies is guitar. and when i'm playing guitar this works great.", new DateTime(2024, 4, 17, 22, 46, 54, 25, DateTimeKind.Unspecified).AddTicks(1806), "Review\\11_img.png", null, 3.3793705f, 4 },
                    { 12, 6, "talk about sadness!!", new DateTime(2024, 5, 11, 16, 22, 2, 385, DateTimeKind.Unspecified).AddTicks(5541), "Review\\12_img.png", null, 1.8585588f, 4 },
                    { 13, 1, "one of my hobbies is drawing. and when i'm drawing this works great.", new DateTime(2024, 4, 16, 8, 18, 47, 64, DateTimeKind.Unspecified).AddTicks(756), "Review\\13_img.png", null, 3.898978f, 4 },
                    { 14, 6, "My neighbor Forest has one of these. She works as a gardener and she says it looks nude.", new DateTime(2024, 4, 23, 1, 53, 27, 27, DateTimeKind.Unspecified).AddTicks(4614), "Review\\14_img.png", null, 1.6039214f, 4 },
                    { 15, 4, "this product is perplexed.", new DateTime(2024, 4, 30, 15, 47, 1, 984, DateTimeKind.Unspecified).AddTicks(1992), "Review\\15_img.png", null, 1.9781153f, 4 },
                    { 16, 6, "this product is brown.", new DateTime(2024, 5, 11, 15, 20, 40, 371, DateTimeKind.Unspecified).AddTicks(1707), "Review\\16_img.png", null, 1.0308427f, 5 },
                    { 17, 6, "My co-worker Nile has one of these. He says it looks crooked.", new DateTime(2024, 4, 15, 22, 48, 30, 743, DateTimeKind.Unspecified).AddTicks(8579), "Review\\17_img.png", null, 2.6860995f, 5 },
                    { 18, 2, "My co-worker Delton has one of these. He says it looks slender.", new DateTime(2024, 4, 19, 16, 13, 15, 10, DateTimeKind.Unspecified).AddTicks(8434), "Review\\18_img.png", null, 3.5856678f, 5 },
                    { 19, 7, "It only works when I'm Bahrain.", new DateTime(2024, 5, 10, 22, 34, 30, 687, DateTimeKind.Unspecified).AddTicks(7372), "Review\\19_img.png", null, 4.8668694f, 5 },
                    { 20, 2, "i use it centenially when i'm in my greenhouse.", new DateTime(2024, 5, 13, 1, 38, 37, 383, DateTimeKind.Unspecified).AddTicks(9842), "Review\\20_img.png", null, 3.216291f, 5 },
                    { 21, 1, "I saw one of these in South Korea and I bought one.", new DateTime(2024, 5, 3, 21, 25, 9, 329, DateTimeKind.Unspecified).AddTicks(5399), "Review\\21_img.png", null, 3.7783077f, 6 },
                    { 22, 10, "My penguin loves to play with it.", new DateTime(2024, 4, 21, 13, 31, 38, 530, DateTimeKind.Unspecified).AddTicks(3914), "Review\\22_img.png", null, 4.256325f, 6 },
                    { 23, 1, "heard about this on powerviolence radio, decided to give it a try.", new DateTime(2024, 4, 28, 20, 35, 57, 637, DateTimeKind.Unspecified).AddTicks(3715), "Review\\23_img.png", null, 1.1811595f, 6 },
                    { 24, 4, "talk about hatred.", new DateTime(2024, 4, 25, 18, 6, 11, 65, DateTimeKind.Unspecified).AddTicks(5025), "Review\\24_img.png", null, 3.265112f, 6 },
                    { 25, 6, "It only works when I'm Azerbaijan.", new DateTime(2024, 5, 5, 16, 31, 25, 82, DateTimeKind.Unspecified).AddTicks(6096), "Review\\25_img.png", null, 2.4731367f, 6 },
                    { 26, 2, "My co-worker Matthew has one of these. He says it looks gigantic.", new DateTime(2024, 4, 28, 1, 46, 41, 257, DateTimeKind.Unspecified).AddTicks(1673), "Review\\26_img.png", null, 2.315417f, 7 },
                    { 27, 8, "This product works so well. It imperfectly improves my baseball by a lot.", new DateTime(2024, 4, 16, 4, 18, 42, 773, DateTimeKind.Unspecified).AddTicks(7720), "Review\\27_img.png", null, 4.5309005f, 7 },
                    { 28, 9, "My co-worker Archer has one of these. He says it looks crooked.", new DateTime(2024, 5, 13, 21, 45, 15, 864, DateTimeKind.Unspecified).AddTicks(5875), "Review\\28_img.png", null, 3.6736598f, 8 },
                    { 29, 2, "It only works when I'm Juan de Nova Island.", new DateTime(2024, 5, 1, 15, 0, 34, 351, DateTimeKind.Unspecified).AddTicks(3332), "Review\\29_img.png", null, 1.4414985f, 8 },
                    { 30, 7, "talk about hatred!!!", new DateTime(2024, 4, 16, 15, 10, 47, 135, DateTimeKind.Unspecified).AddTicks(5655), "Review\\30_img.png", null, 2.8787034f, 8 },
                    { 31, 2, "My locust loves to play with it.", new DateTime(2024, 4, 27, 9, 49, 24, 235, DateTimeKind.Unspecified).AddTicks(1851), "Review\\31_img.png", null, 4.2017775f, 9 },
                    { 32, 9, "My terrier loves to play with it.", new DateTime(2024, 4, 26, 19, 59, 50, 677, DateTimeKind.Unspecified).AddTicks(8619), "Review\\32_img.png", null, 1.0393814f, 9 },
                    { 33, 9, "heard about this on hip-hop music radio, decided to give it a try.", new DateTime(2024, 4, 27, 16, 29, 31, 509, DateTimeKind.Unspecified).AddTicks(6551), "Review\\33_img.png", null, 2.4113457f, 9 },
                    { 34, 6, "My bass loves to play with it.", new DateTime(2024, 5, 12, 18, 51, 47, 737, DateTimeKind.Unspecified).AddTicks(6445), "Review\\34_img.png", null, 2.222295f, 10 },
                    { 35, 10, "I saw one of these in Barbados and I bought one.", new DateTime(2024, 4, 26, 10, 29, 24, 712, DateTimeKind.Unspecified).AddTicks(5103), "Review\\35_img.png", null, 4.826823f, 10 },
                    { 36, 8, "I saw one of these in South Korea and I bought one.", new DateTime(2024, 5, 12, 19, 29, 54, 497, DateTimeKind.Unspecified).AddTicks(1098), "Review\\36_img.png", null, 3.6194806f, 11 },
                    { 37, 6, "i use it until further notice when i'm in my nightclub.", new DateTime(2024, 5, 6, 15, 30, 12, 523, DateTimeKind.Unspecified).AddTicks(9387), "Review\\37_img.png", null, 3.117349f, 11 },
                    { 38, 10, "My co-worker Kazuo has one of these. He says it looks transparent.", new DateTime(2024, 5, 7, 19, 48, 54, 293, DateTimeKind.Unspecified).AddTicks(8178), "Review\\38_img.png", null, 3.280115f, 11 },
                    { 39, 6, "heard about this on Kansas City jazz radio, decided to give it a try.", new DateTime(2024, 5, 9, 16, 15, 6, 699, DateTimeKind.Unspecified).AddTicks(2853), "Review\\39_img.png", null, 4.927922f, 11 },
                    { 40, 10, "I tried to belly-flop it but got Turkish Delight all over it.", new DateTime(2024, 4, 20, 7, 15, 20, 646, DateTimeKind.Unspecified).AddTicks(2990), "Review\\40_img.png", null, 4.6958613f, 11 },
                    { 41, 14, "I saw one of these in Macau and I bought one.", new DateTime(2024, 4, 24, 19, 31, 21, 616, DateTimeKind.Unspecified).AddTicks(8760), "Review\\41_img.png", null, 1.3269621f, 12 },
                    { 42, 10, "heard about this on gypsy jazz radio, decided to give it a try.", new DateTime(2024, 5, 8, 12, 0, 31, 34, DateTimeKind.Unspecified).AddTicks(4187), "Review\\42_img.png", null, 3.1839042f, 12 },
                    { 43, 4, "My bass loves to play with it.", new DateTime(2024, 4, 19, 23, 50, 36, 739, DateTimeKind.Unspecified).AddTicks(9385), "Review\\43_img.png", null, 2.8383882f, 12 },
                    { 44, 11, "It only works when I'm Malaysia.", new DateTime(2024, 4, 27, 8, 48, 59, 935, DateTimeKind.Unspecified).AddTicks(3586), "Review\\44_img.png", null, 4.1395006f, 13 },
                    { 45, 7, "i use it daily when i'm in my courthouse.", new DateTime(2024, 5, 4, 5, 11, 0, 270, DateTimeKind.Unspecified).AddTicks(2123), "Review\\45_img.png", null, 3.8482714f, 13 },
                    { 46, 5, "The box this comes in is 5 light-year by 6 foot and weights 17 megaton!!!", new DateTime(2024, 5, 2, 13, 5, 18, 668, DateTimeKind.Unspecified).AddTicks(227), "Review\\46_img.png", null, 3.4949102f, 13 },
                    { 47, 1, "one of my hobbies is gaming. and when i'm gaming this works great.", new DateTime(2024, 5, 1, 4, 34, 12, 1, DateTimeKind.Unspecified).AddTicks(2932), "Review\\47_img.png", null, 3.441641f, 13 },
                    { 48, 6, "one of my hobbies is theater. and when i'm acting this works great.", new DateTime(2024, 5, 8, 16, 34, 13, 841, DateTimeKind.Unspecified).AddTicks(3151), "Review\\48_img.png", null, 2.0109577f, 14 },
                    { 49, 1, "heard about this on rebetiko radio, decided to give it a try.", new DateTime(2024, 4, 30, 1, 7, 10, 395, DateTimeKind.Unspecified).AddTicks(1401), "Review\\49_img.png", null, 4.4595647f, 14 },
                    { 50, 15, "I tried to scratch it but got cheeseburger all over it.", new DateTime(2024, 4, 17, 11, 59, 41, 108, DateTimeKind.Unspecified).AddTicks(8274), "Review\\50_img.png", null, 3.9548473f, 14 },
                    { 51, 2, "talk about lust!!", new DateTime(2024, 4, 20, 11, 50, 37, 584, DateTimeKind.Unspecified).AddTicks(3572), "Review\\51_img.png", null, 1.4019188f, 15 },
                    { 52, 6, "I saw one of these in Vanuatu and I bought one.", new DateTime(2024, 5, 7, 6, 55, 40, 688, DateTimeKind.Unspecified).AddTicks(7001), "Review\\52_img.png", null, 3.1971514f, 15 },
                    { 53, 15, "i use it on Mondays when i'm in my fort.", new DateTime(2024, 4, 27, 13, 3, 34, 467, DateTimeKind.Unspecified).AddTicks(2011), "Review\\53_img.png", null, 2.4455922f, 16 },
                    { 54, 7, "this product is hyper.", new DateTime(2024, 4, 29, 16, 22, 30, 793, DateTimeKind.Unspecified).AddTicks(664), "Review\\54_img.png", null, 2.618519f, 16 },
                    { 55, 4, "one of my hobbies is skydiving. and when i'm skydiving this works great.", new DateTime(2024, 4, 27, 23, 39, 31, 355, DateTimeKind.Unspecified).AddTicks(4374), "Review\\55_img.png", null, 3.2857263f, 16 },
                    { 56, 15, "The box this comes in is 4 light-year by 5 inch and weights 11 megaton!!", new DateTime(2024, 4, 27, 7, 50, 43, 99, DateTimeKind.Unspecified).AddTicks(8797), "Review\\56_img.png", null, 3.5437818f, 17 },
                    { 57, 11, "My chicken loves to play with it.", new DateTime(2024, 4, 17, 19, 42, 4, 584, DateTimeKind.Unspecified).AddTicks(825), "Review\\57_img.png", null, 2.4327207f, 17 },
                    { 58, 18, "This product works quite well. It romantically improves my golf by a lot.", new DateTime(2024, 5, 3, 16, 4, 20, 790, DateTimeKind.Unspecified).AddTicks(7573), "Review\\58_img.png", null, 1.7066371f, 18 },
                    { 59, 15, "I tried to cremate it but got Turkish Delight all over it.", new DateTime(2024, 5, 4, 21, 39, 11, 371, DateTimeKind.Unspecified).AddTicks(3728), "Review\\59_img.png", null, 1.7800055f, 18 },
                    { 60, 8, "The box this comes in is 3 light-year by 5 meter and weights 10 ounce!", new DateTime(2024, 5, 3, 3, 10, 32, 826, DateTimeKind.Unspecified).AddTicks(852), "Review\\60_img.png", null, 3.096649f, 18 },
                    { 61, 16, "It only works when I'm Kuwait.", new DateTime(2024, 5, 3, 10, 26, 24, 267, DateTimeKind.Unspecified).AddTicks(837), "Review\\61_img.png", null, 1.5268036f, 18 },
                    { 62, 11, "My neighbor Ardeth has one of these. She works as a gasman and she says it looks fuzzy.", new DateTime(2024, 4, 21, 22, 12, 58, 752, DateTimeKind.Unspecified).AddTicks(252), "Review\\62_img.png", null, 3.45732f, 18 },
                    { 63, 5, "My neighbor Montserrat has one of these. She works as a circus performer and she says it looks shriveled.", new DateTime(2024, 4, 28, 4, 17, 16, 150, DateTimeKind.Unspecified).AddTicks(7934), "Review\\63_img.png", null, 1.1208196f, 19 },
                    { 64, 8, "The box this comes in is 3 meter by 6 yard and weights 12 pound.", new DateTime(2024, 4, 26, 10, 43, 53, 420, DateTimeKind.Unspecified).AddTicks(7807), "Review\\64_img.png", null, 2.7169034f, 19 },
                    { 65, 10, "My Shih-Tzu loves to play with it.", new DateTime(2024, 5, 9, 16, 14, 48, 101, DateTimeKind.Unspecified).AddTicks(2326), "Review\\65_img.png", null, 2.3209271f, 19 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "LastModifiedDate", "ReviewId", "ReviewerId" },
                values: new object[,]
                {
                    { 1, "heard about this on powerviolence radio, decided to give it a try.", new DateTime(2024, 5, 1, 21, 51, 27, 149, DateTimeKind.Unspecified).AddTicks(1922), null, 5, 1 },
                    { 2, "The box this comes in is 3 light-year by 5 meter and weights 10 ounce!", new DateTime(2024, 5, 10, 10, 5, 59, 706, DateTimeKind.Unspecified).AddTicks(5508), null, 5, 1 },
                    { 3, "My velociraptor loves to play with it.", new DateTime(2024, 5, 4, 7, 38, 35, 570, DateTimeKind.Unspecified).AddTicks(1367), null, 2, 1 },
                    { 4, "this product is top-notch.", new DateTime(2024, 5, 6, 1, 6, 15, 640, DateTimeKind.Unspecified).AddTicks(1919), null, 7, 2 },
                    { 5, "I tried to kidnap it but got apricot all over it.", new DateTime(2024, 4, 24, 4, 12, 31, 372, DateTimeKind.Unspecified).AddTicks(1495), null, 8, 2 },
                    { 6, "this product is standard.", new DateTime(2024, 4, 23, 16, 1, 2, 464, DateTimeKind.Unspecified).AddTicks(4397), null, 5, 2 },
                    { 7, "My co-worker Skylar has one of these. He says it looks sweaty.", new DateTime(2024, 4, 26, 9, 55, 7, 66, DateTimeKind.Unspecified).AddTicks(2405), null, 3, 2 },
                    { 8, "The box this comes in is 5 yard by 6 centimeter and weights 18 gram!!", new DateTime(2024, 5, 5, 13, 0, 43, 61, DateTimeKind.Unspecified).AddTicks(4472), null, 4, 3 },
                    { 9, "this product is snowy.", new DateTime(2024, 4, 27, 10, 34, 30, 231, DateTimeKind.Unspecified).AddTicks(4788), null, 2, 3 },
                    { 10, "My vulture loves to play with it.", new DateTime(2024, 4, 23, 16, 52, 53, 521, DateTimeKind.Unspecified).AddTicks(4421), null, 2, 3 },
                    { 11, "It only works when I'm South Korea.", new DateTime(2024, 5, 7, 9, 33, 40, 93, DateTimeKind.Unspecified).AddTicks(5151), null, 6, 3 },
                    { 12, "My velociraptor loves to play with it.", new DateTime(2024, 4, 26, 21, 44, 20, 914, DateTimeKind.Unspecified).AddTicks(601), null, 2, 3 },
                    { 13, "one of my hobbies is theater. and when i'm acting this works great.", new DateTime(2024, 5, 11, 20, 39, 54, 838, DateTimeKind.Unspecified).AddTicks(3241), null, 11, 4 },
                    { 14, "this product is whole-grain.", new DateTime(2024, 4, 27, 11, 3, 25, 427, DateTimeKind.Unspecified).AddTicks(4625), null, 3, 4 },
                    { 15, "My neighbor Lonnie has one of these. She works as a hobbit and she says it looks microscopic.", new DateTime(2024, 4, 24, 14, 10, 2, 356, DateTimeKind.Unspecified).AddTicks(9230), null, 12, 4 },
                    { 16, "this product is perplexed.", new DateTime(2024, 5, 2, 4, 22, 50, 641, DateTimeKind.Unspecified).AddTicks(1266), null, 7, 4 },
                    { 17, "i use it occasionally when i'm in my outhouse.", new DateTime(2024, 4, 25, 10, 47, 48, 60, DateTimeKind.Unspecified).AddTicks(5587), null, 3, 5 },
                    { 18, "My co-worker Atha has one of these. He says it looks narrow.", new DateTime(2024, 5, 1, 3, 36, 3, 680, DateTimeKind.Unspecified).AddTicks(9771), null, 11, 5 },
                    { 19, "My co-worker Merwin has one of these. He says it looks bubbly.", new DateTime(2024, 5, 2, 10, 57, 38, 175, DateTimeKind.Unspecified).AddTicks(5006), null, 11, 5 },
                    { 20, "heard about this on wonky radio, decided to give it a try.", new DateTime(2024, 4, 22, 7, 11, 11, 958, DateTimeKind.Unspecified).AddTicks(326), null, 6, 5 },
                    { 21, "talk about pleasure.", new DateTime(2024, 5, 9, 13, 25, 49, 924, DateTimeKind.Unspecified).AddTicks(7213), null, 9, 5 },
                    { 22, "My locust loves to play with it.", new DateTime(2024, 4, 26, 11, 26, 1, 662, DateTimeKind.Unspecified).AddTicks(8231), null, 2, 6 },
                    { 23, "talk about interest!!", new DateTime(2024, 5, 13, 13, 52, 49, 383, DateTimeKind.Unspecified).AddTicks(7297), null, 8, 6 },
                    { 24, "this product is papery.", new DateTime(2024, 4, 15, 9, 2, 6, 942, DateTimeKind.Unspecified).AddTicks(8864), null, 4, 6 },
                    { 25, "I tried to electrocute it but got sweetmeat all over it.", new DateTime(2024, 5, 5, 23, 17, 55, 844, DateTimeKind.Unspecified).AddTicks(8575), null, 16, 6 },
                    { 26, "It only works when I'm Wake Island.", new DateTime(2024, 4, 28, 18, 9, 33, 534, DateTimeKind.Unspecified).AddTicks(497), null, 8, 7 },
                    { 27, "heard about this on new jersey hip hop radio, decided to give it a try.", new DateTime(2024, 4, 23, 3, 23, 28, 671, DateTimeKind.Unspecified).AddTicks(3518), null, 13, 7 },
                    { 28, "The box this comes in is 3 kilometer by 5 inch and weights 13 ton.", new DateTime(2024, 5, 10, 10, 28, 59, 602, DateTimeKind.Unspecified).AddTicks(139), null, 4, 8 },
                    { 29, "i use it never when i'm in my nightclub.", new DateTime(2024, 4, 24, 15, 58, 29, 18, DateTimeKind.Unspecified).AddTicks(9201), null, 8, 8 },
                    { 30, "The box this comes in is 3 kilometer by 5 foot and weights 16 megaton!!!", new DateTime(2024, 5, 4, 6, 4, 18, 65, DateTimeKind.Unspecified).AddTicks(551), null, 21, 8 },
                    { 31, "It only works when I'm Martinique.", new DateTime(2024, 4, 24, 7, 35, 18, 425, DateTimeKind.Unspecified).AddTicks(6593), null, 28, 8 },
                    { 32, "one of my hobbies is drawing. and when i'm drawing this works great.", new DateTime(2024, 4, 16, 22, 47, 3, 72, DateTimeKind.Unspecified).AddTicks(6594), null, 21, 8 },
                    { 33, "It only works when I'm Malaysia.", new DateTime(2024, 4, 30, 7, 39, 22, 483, DateTimeKind.Unspecified).AddTicks(5213), null, 3, 9 },
                    { 34, "talk about sadness.", new DateTime(2024, 4, 29, 3, 24, 36, 168, DateTimeKind.Unspecified).AddTicks(7039), null, 26, 9 },
                    { 35, "My co-worker Cato has one of these. He says it looks sopping.", new DateTime(2024, 5, 4, 1, 37, 22, 96, DateTimeKind.Unspecified).AddTicks(6422), null, 27, 9 },
                    { 36, "I tried to strangle it but got hazelnut all over it.", new DateTime(2024, 5, 12, 18, 19, 11, 684, DateTimeKind.Unspecified).AddTicks(9177), null, 3, 9 },
                    { 37, "heard about this on dance-rock radio, decided to give it a try.", new DateTime(2024, 4, 14, 22, 49, 8, 227, DateTimeKind.Unspecified).AddTicks(8212), null, 19, 10 },
                    { 38, "My co-worker Bryton has one of these. He says it looks ragged.", new DateTime(2024, 5, 11, 11, 27, 16, 391, DateTimeKind.Unspecified).AddTicks(3204), null, 13, 10 },
                    { 39, "The box this comes in is 3 yard by 6 light-year and weights 11 megaton!!", new DateTime(2024, 5, 10, 15, 42, 51, 659, DateTimeKind.Unspecified).AddTicks(4556), null, 28, 11 },
                    { 40, "this product is mellow.", new DateTime(2024, 5, 2, 3, 41, 37, 19, DateTimeKind.Unspecified).AddTicks(960), null, 21, 11 },
                    { 41, "talk about pleasure.", new DateTime(2024, 4, 25, 3, 18, 15, 789, DateTimeKind.Unspecified).AddTicks(8261), null, 38, 11 },
                    { 42, "This product works certainly well. It accidentally improves my baseball by a lot.", new DateTime(2024, 4, 17, 14, 20, 54, 812, DateTimeKind.Unspecified).AddTicks(1625), null, 40, 11 },
                    { 43, "this product is revolting.", new DateTime(2024, 4, 21, 11, 59, 17, 644, DateTimeKind.Unspecified).AddTicks(5788), null, 35, 12 },
                    { 44, "i use it from now on when i'm in my safehouse.", new DateTime(2024, 5, 4, 21, 3, 33, 197, DateTimeKind.Unspecified).AddTicks(8704), null, 33, 12 },
                    { 45, "i use it from now on when i'm in my safehouse.", new DateTime(2024, 4, 27, 17, 28, 27, 381, DateTimeKind.Unspecified).AddTicks(4056), null, 4, 13 },
                    { 46, "My neighbor Isabela has one of these. She works as a taxidermist and she says it looks monochromatic.", new DateTime(2024, 5, 1, 1, 16, 43, 244, DateTimeKind.Unspecified).AddTicks(1836), null, 13, 13 },
                    { 47, "This product works certainly well. It excitedly improves my football by a lot.", new DateTime(2024, 5, 5, 6, 22, 3, 307, DateTimeKind.Unspecified).AddTicks(4292), null, 36, 13 },
                    { 48, "heard about this on ndombolo radio, decided to give it a try.", new DateTime(2024, 5, 10, 22, 45, 45, 548, DateTimeKind.Unspecified).AddTicks(3721), null, 32, 14 },
                    { 49, "My co-worker Aurthur has one of these. He says it looks white.", new DateTime(2024, 5, 7, 17, 11, 58, 101, DateTimeKind.Unspecified).AddTicks(4074), null, 34, 14 },
                    { 50, "I saw one of these in Juan de Nova Island and I bought one.", new DateTime(2024, 4, 21, 5, 59, 8, 559, DateTimeKind.Unspecified).AddTicks(3897), null, 3, 15 },
                    { 51, "It only works when I'm Wake Island.", new DateTime(2024, 4, 20, 14, 44, 21, 555, DateTimeKind.Unspecified).AddTicks(2656), null, 49, 15 },
                    { 52, "The box this comes in is 5 inch by 6 mile and weights 15 ton!!", new DateTime(2024, 5, 1, 22, 34, 52, 854, DateTimeKind.Unspecified).AddTicks(9524), null, 6, 16 },
                    { 53, "this product is honest.", new DateTime(2024, 5, 2, 7, 48, 47, 576, DateTimeKind.Unspecified).AddTicks(7068), null, 5, 16 },
                    { 54, "It only works when I'm Malaysia.", new DateTime(2024, 4, 28, 16, 25, 6, 179, DateTimeKind.Unspecified).AddTicks(3857), null, 50, 16 },
                    { 55, "My neighbor Ardeth has one of these. She works as a gasman and she says it looks fuzzy.", new DateTime(2024, 4, 27, 12, 5, 14, 960, DateTimeKind.Unspecified).AddTicks(4717), null, 8, 16 },
                    { 56, "I tried to attack it but got meatball all over it.", new DateTime(2024, 5, 12, 3, 42, 32, 834, DateTimeKind.Unspecified).AddTicks(4871), null, 13, 16 },
                    { 57, "talk about anticipation!", new DateTime(2024, 4, 29, 10, 43, 6, 580, DateTimeKind.Unspecified).AddTicks(2560), null, 24, 17 },
                    { 58, "i use it every Tuesday when i'm in my homeless shelter.", new DateTime(2024, 4, 30, 18, 50, 19, 124, DateTimeKind.Unspecified).AddTicks(5841), null, 37, 17 },
                    { 59, "heard about this on melodic death metal radio, decided to give it a try.", new DateTime(2024, 5, 8, 5, 39, 27, 238, DateTimeKind.Unspecified).AddTicks(1560), null, 40, 18 },
                    { 60, "heard about this on alternative dance radio, decided to give it a try.", new DateTime(2024, 5, 7, 15, 57, 10, 678, DateTimeKind.Unspecified).AddTicks(2680), null, 57, 18 },
                    { 61, "heard about this on bouyon radio, decided to give it a try.", new DateTime(2024, 5, 10, 3, 37, 3, 49, DateTimeKind.Unspecified).AddTicks(4488), null, 17, 18 },
                    { 62, "The box this comes in is 3 yard by 6 light-year and weights 11 megaton!!", new DateTime(2024, 4, 15, 14, 14, 1, 502, DateTimeKind.Unspecified).AddTicks(2239), null, 56, 19 },
                    { 63, "It only works when I'm Finland.", new DateTime(2024, 4, 18, 8, 58, 6, 418, DateTimeKind.Unspecified).AddTicks(1399), null, 14, 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_BusinessId",
                table: "Attachments",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeReviewer_ReviewersId",
                table: "BadgeReviewer",
                column: "ReviewersId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_OwnerId",
                table: "Businesses",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_SubCategoryId",
                table: "Businesses",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilter_FiltersId",
                table: "CategoryFilter",
                column: "FiltersId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewerId",
                table: "Comments",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewId",
                table: "Comments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_FilterId",
                table: "Options",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviewers_UserId",
                table: "Reviewers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BusinessId",
                table: "Reviews",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsReaction_ReactionId",
                table: "ReviewsReaction",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsReaction_ReviewerId",
                table: "ReviewsReaction",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "BadgeReviewer");

            migrationBuilder.DropTable(
                name: "CategoryFilter");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "ReviewsReaction");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Reviewers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
